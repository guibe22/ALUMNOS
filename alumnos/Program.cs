using System;

class Program
{
    static void Main()
    {
        int años = 10; // número de años a simular
        int[] alumnos = new int[8]; // número de alumnos por año (indexado de 1 a 7)
        int nuevosAlumnos = 100; // número de nuevos alumnos que entran cada año

        // Porcentajes de transición (expresados como decimales)
        double[] a = { 0, 0.8, 0.7, 0.6, 0.5, 0.4, 0.3, 0 }; // índice 0 no se usa
        double[] b = { 0, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4 };
        double[] c = { 0, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4 };

        // Nuevas tasas
        double tasaDesercion = 0.1; // Tasa de deserción
        double tasaAbandono = 0.05; // Tasa de abandono
        double tasaLicenciaMedica = 0.02; // Tasa de licencia médica
        double tasaIngreso = 0.9; // Tasa de ingreso a la universidad

        Random rnd = new Random();
        int intervalo = rnd.Next(1, 6); // Intervalo aleatorio de 1 a 5 años

        for (int t = 1; t <= intervalo; t++)
        {
            // Actualizamos el número de alumnos que ingresan al primer año
            int nuevosIngresos = (int)(nuevosAlumnos * tasaIngreso);
            int[] nuevosAlumnosPorAño = new int[8];

            // Año 1
            nuevosAlumnosPorAño[1] = nuevosIngresos + (int)(c[1] * alumnos[1]);

            // Años 2 a 7
            for (int i = 2; i <= 7; i++)
            {
                nuevosAlumnosPorAño[i] = (int)(a[i - 1] * alumnos[i - 1]) + (int)(c[i] * alumnos[i]);
                nuevosAlumnosPorAño[i] -= (int)(tasaDesercion * nuevosAlumnosPorAño[i]);
                nuevosAlumnosPorAño[i] -= (int)(tasaAbandono * nuevosAlumnosPorAño[i]);
                nuevosAlumnosPorAño[i] -= (int)(tasaLicenciaMedica * nuevosAlumnosPorAño[i]);
            }

            // Actualizamos el número de alumnos para el siguiente ciclo
            for (int i = 1; i <= 7; i++)
            {
                alumnos[i] = nuevosAlumnosPorAño[i];
            }

            // Imprimimos los resultados del año actual
            Console.WriteLine($"Año {t}:");
            for (int i = 1; i <= 7; i++)
            {
                Console.WriteLine($"  Año {i}: {alumnos[i]} alumnos");
            }
        }

        // Contar total de estudiantes que transitaron por la universidad
        int totalEstudiantes = 0;
        for (int i = 1; i <= 7; i++)
        {
            totalEstudiantes += alumnos[i];
        }
        Console.WriteLine($"Total de estudiantes que transitaron por la universidad: {totalEstudiantes}");
    }
}
