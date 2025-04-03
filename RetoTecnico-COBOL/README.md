Procesamiento de Transacciones Bancarias (CLI)
El procesamiento efectivo de transacciones bancarias es una tarea primordial en el ámbito financiero.
Este reto técnico propone el desarrollo de una aplicación de línea de comandos (CLI) en C# que analice
un archivo CSV con transacciones bancarias y genere un reporte con métricas clave.


Breve Descripción del Reto y su Propósito
El objetivo de esta aplicación es procesar un archivo CSV que contiene transacciones de tipo
"Crédito" y "Débito" para generar un reporte con la siguiente información:

-Balance Final: Suma de los montos de las transacciones de tipo "Crédito" menos la suma de los montos de las
transacciones de tipo "Débito".

-Transacción de Mayor Monto: Identificar el ID y el monto de la transacción con el valor más alto.

-Conteo de Transacciones: Número total de transacciones para cada tipo ("Crédito" y "Débito").

Instrucciones de Ejecución

Requisitos Previos

-Tener instalado .NET SDK 6.0 o superior.

-Editor de código recomendado: Visual Studio Code o Visual Studio.

Instalación y Ejecución

1. Clona este repositorio: git clone https://github.com/tu_usuario/procesador-transacciones-cli.git
cd procesador-transacciones-cli

2. Compila el proyecto: dotnet build

3. Ejecuta la aplicación desde la terminal con el archivo CSV de entrada: dotnet run transacciones.csv

Entrada de Datos

La aplicación leerá un archivo CSV con el siguiente formato: 
id,tipo,monto
1,Crédito,100.00
2,Débito,50.00
3,Crédito,200.00
4,Débito,75.00
5,Crédito,150.00

Salida Esperada en la Terminal
Reporte de Transacciones:
Balance Final: 325.00
Transacción de Mayor Monto: ID 3 - 200.00
Conteo de Transacciones: Crédito: 3 Débito: 2

Enfoque y Solución

Lógica Implementada

1.Lectura del Archivo CSV: Se usa la biblioteca System.IO para leer el contenido del archivo CSV.

2.Procesamiento de Datos: Se utiliza List<T> para almacenar las transacciones y calcular el balance final, la transacción de mayor monto y el conteo de transacciones.

3.Generación del Reporte: Se imprimen los resultados en la terminal en un formato claro y estructurado

Decisiones de Diseño

-Se eligió C# debido a su eficiencia y facilidad para manejar archivos y estructuras de datos.

-Se implementó un enfoque modular separando la lectura, el procesamiento y la generación del reporte en métodos distintos.

-Se validan los datos de entrada para evitar errores durante la ejecución.

Contribución

Si deseas contribuir a este proyecto:

1.Haz un fork del repositorio.

2.Crea una nueva rama (git checkout -b feature-nueva-funcionalidad).

3.Realiza tus modificaciones y haz commit (git commit -m 'Añadir nueva funcionalidad').

4.Envía un push a la rama (git push origin feature-nueva-funcionalidad).

5.Abre un Pull Request.

Licencia

Este proyecto se distribuye bajo la licencia MIT.