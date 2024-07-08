int x = 100; // ejemplo: 100 alumnos ingresan cada año

// Arreglo para almacenar la cantidad de alumnos por año (5 años de carrera)
int[] alumnosPorAño = new int[5];

// Definir los porcentajes iniciales para pasar al siguiente año y repetir
double[] a = { 0.0, 0.70, 0.75, 0.80, 0.85 }; // porcentajes de pasar al siguiente año
double[] c = { 0.0, 0.25, 0.20, 0.15, 0.10 }; // porcentajes de repetir

// Generar valores aleatorios para a y c dentro de un rango predefinido
Random random = new Random();
for (int i = 1; i < a.Length; i++)
{
    a[i] = random.NextDouble() * 0.15 + 0.70; // valores entre 0.70 y 0.85
    c[i] = random.NextDouble() * 0.15 + 0.10; // valores entre 0.10 y 0.25
}

// Calcular para el primer año (t = 1)
alumnosPorAño[0] = x;

// Calcular para los años restantes (t > 1)
for (int t = 2; t <= 5; t++)
{
    // Calcular el número de alumnos para el año t
    alumnosPorAño[t - 1] = Convert.ToInt32(alumnosPorAño[t - 2] * a[t - 1]); // pasa al siguiente año
    alumnosPorAño[t - 1] += Convert.ToInt32(alumnosPorAño[t - 2] * c[t - 1]); // se queda repitiendo
}

// Mostrar los resultados
Console.WriteLine("Cantidad de alumnos por año:");
for (int t = 1; t <= 5; t++)
{
    Console.WriteLine($"Año {t}: {alumnosPorAño[t - 1]} alumnos");
}