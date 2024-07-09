int años = 10; // número de años a simular
int[] alumnos = new int[6]; // número de alumnos por año (indexado de 1 a 5)
int nuevosAlumnos = 100; // número de nuevos alumnos que entran cada año

// Porcentajes de transición (expresados como decimales)
double[] a = { 0, 0.8, 0.7, 0.6, 0.5, 0 }; // índice 0 no se usa
double[] b = { 0, 0.1, 0.15, 0.2, 0.25, 0.3 };
double[] c = { 0, 0.1, 0.15, 0.2, 0.25, 0.3 };

for (int t = 1; t <= años; t++)
{
    // Actualizamos el número de alumnos que ingresan al primer año
    int nuevosIngresos = nuevosAlumnos;
    int[] nuevosAlumnosPorAño = new int[6];

    // Año 1
    nuevosAlumnosPorAño[1] = nuevosIngresos + (int)(c[1] * alumnos[1]);

    // Años 2 a 5
    for (int i = 2; i <= 5; i++)
    {
        nuevosAlumnosPorAño[i] = (int)(a[i - 1] * alumnos[i - 1]) + (int)(c[i] * alumnos[i]);
    }

    // Actualizamos el número de alumnos para el siguiente ciclo
    for (int i = 1; i <= 5; i++)
    {
        alumnos[i] = nuevosAlumnosPorAño[i];
    }

    // Imprimimos los resultados del año actual
    Console.WriteLine($"Año {t}:");
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine($"  Año {i}: {alumnos[i]} alumnos");
    }
}