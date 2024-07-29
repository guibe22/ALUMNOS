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
            // Calculamos el número de nuevos ingresos al primer año aplicando la tasa de ingreso
            // Si nuevosAlumnos es 100 y la tasaIngreso es 0.9, entonces nuevosIngresos será 90.
            int nuevosIngresos = (int)(nuevosAlumnos * tasaIngreso);
            
            // Creamos un array temporal para almacenar el número de alumnos por cada año en este ciclo
            int[] nuevosAlumnosPorAño = new int[8];

            // Año 1:
            // Calculamos el número de alumnos que ingresan al primer año.
            // Sumamos los nuevos ingresos (nuevosIngresos) y el porcentaje de alumnos del primer año
            // que se reincorporan debido a licencias médicas (c[1] * alumnos[1]).
            nuevosAlumnosPorAño[1] = nuevosIngresos + (int)(c[1] * alumnos[1]);

            // Años 2 a 7:
            for (int i = 2; i <= 7; i++)
            {
                // Calculamos el número de alumnos que pasan del año anterior (i-1) al año actual (i)
                // Se multiplican los alumnos del año anterior por la tasa de transición 'a' y se añade
                // un porcentaje de los alumnos actuales que se reincorporan por licencias médicas 'c'
                nuevosAlumnosPorAño[i] = (int)(a[i - 1] * alumnos[i - 1]) + (int)(c[i] * alumnos[i]);

                // Restamos los alumnos que desertan (tasaDesercion)
                // La tasa de deserción se aplica al número calculado de alumnos en el año actual
                nuevosAlumnosPorAño[i] -= (int)(tasaDesercion * nuevosAlumnosPorAño[i]);

                // Restamos los alumnos que abandonan (tasaAbandono)
                // La tasa de abandono se aplica al número de alumnos restantes después de descontar la deserción
                nuevosAlumnosPorAño[i] -= (int)(tasaAbandono * nuevosAlumnosPorAño[i]);

                // Restamos los alumnos que toman licencia médica (tasaLicenciaMedica)
                // La tasa de licencia médica se aplica al número de alumnos restantes después de descontar la deserción y el abandono
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
