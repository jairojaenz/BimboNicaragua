import edaSQL  # Importa la biblioteca edaSQL para el análisis exploratorio de datos
import pandas as pd  # Importa pandas para el manejo de datos
import pyodbc  # Importa pyodbc para la conexión con la base de datos SQL Server
import matplotlib.pyplot as plt  # Importa Matplotlib para la visualización de datos
import mpld3  # Importa mpld3 para generar gráficos dinámicos en HTML
import sys  # Importa sys para acceder a los argumentos del script
import io 

if len(sys.argv) > 1:
    output_file_path = sys.argv[1]  # Leer la ruta del archivo de salida desde los argumentos del script
else:
    # Si no se proporciona, usa un valor predeterminado o termina la ejecución con un mensaje de error
    print("Error: No se proporcionó la ruta del archivo de salida.")
    sys.exit(1)
# Configuración de la conexión a la base de datos
server = 'DESKTOP-7755T4M\\SQLEXPRESS'  # Nombre del servidor SQL Server
database = 'DimencionesPanPlus'  # Nombre de la base de datos
driver = 'ODBC Driver 17 for SQL Server'  # Controlador ODBC utilizado para la conexión

# Intenta establecer la conexión utilizando autenticación de Windows
try:
    conn = pyodbc.connect(
        f'DRIVER={{{driver}}};'
        f'SERVER={server};'
        f'DATABASE={database};'
        'Trusted_Connection=yes;'
    )
except Exception as e:
    with open(output_file_path, 'w', encoding='utf-8') as file:
        file.write(f"Error al conectar a la base de datos: {e}")
    sys.exit(1)

# Query SQL para extraer los datos de la base de datos
query = """
SELECT HechosVentas.[Date Key], Dim_Date.Date, Dimension_Productos.[Nombre Producto], Dimension_Productos.[Descripcion Producto], Dimension_Productos.[Precio Producto], Dimension_Productos.[Categoria Producto], Dimension_Productos.[Nombre Proveedor], Dimension_Productos.[Contacto Proveedor], Dimension_Productos.[Ubicacion Proveedor], 
         HechosVentas.[Cantidad Venta], HechosVentas.[Precio Unitario], Dimension_Cliente.[Nombre Cliente], Dimension_Cliente.[Tipo Cliente], Dimension_Cliente.[Contacto Cliente], Dimension_Cliente.[Ubicacion Cliente], Dimension_Cliente.[Departamento Cliente], Dimension_Cliente.[Municipio Cliente]
FROM  Dim_Date INNER JOIN
         HechosVentas ON Dim_Date.[Date Key] = HechosVentas.[Date Key] INNER JOIN
         Dimension_Cliente ON HechosVentas.[Cliente Key] = Dimension_Cliente.[Cliente Key] INNER JOIN
         Dimension_Productos ON HechosVentas.[Producto Key] = Dimension_Productos.[Producto Key]
"""

# Lee los datos en un DataFrame de pandas desde la base de datos
data = pd.read_sql(query, conn)

# Abre el archivo de salida para escribir el contenido en formato HTML
with open(output_file_path, 'w', encoding='utf-8') as file:
    # Muestra las primeras filas del DataFrame en formato HTML
    file.write("<h2>Primeras 10 filas</h2>")
    file.write(data.head(10).to_html(index=False, classes='table table-striped table-bordered'))

    # Resumen estadístico de las columnas numéricas
    file.write(data.describe().to_html(index=False, classes='table table-striped table-bordered'))

    # Usa edaSQL para generar un análisis exploratorio de datos (EDA)
    eda_report = edaSQL.EDA(dataFrame=data).dataInsights()

    # Formatea el informe EDA en formato HTML
    file.write("<h2>Informe EDA con edaSQL</h2>")
    html_report = "<table border='1' class='table table-striped table-bordered'>"
    for key, value in eda_report.items():
        if isinstance(value, dict):
            html_report += f"<tr><th colspan='2'>{key}</th></tr>"
            for k, v in value.items():
                html_report += f"<tr><td>{k}</td><td>{v}</td></tr>"
        else:
            html_report += f"<tr><td>{key}</td><td>{value}</td></tr>"
    html_report += "</table>"
    file.write(html_report)

    # Realiza un análisis de correlación de Pearson utilizando edaSQL y genera el gráfico con Matplotlib
    eda = edaSQL.EDA(dataFrame=data)
    plt.figure()
    eda.pearsonCorrelation()
    plt.title('Correlación de Pearson')
    # Guardar el gráfico en un objeto de bytes
    buf = io.BytesIO()
    plt.savefig(buf, format='png')
    buf.seek(0)
    
    # Convertir el gráfico de Matplotlib a base64
    import base64
    img_base64 = base64.b64encode(buf.read()).decode('utf-8')
    buf.close()

    # Crear HTML para la imagen
    file.write("<h2>Gráfico de Correlación de Pearson</h2>")
    file.write(f'<img src="data:image/png;base64,{img_base64}" alt="Gráfico de Correlación de Pearson">')
    # Genera el gráfico interactivo con mpld3
    html_fig = mpld3.fig_to_html(plt.gcf())

    # Incrusta el gráfico en el HTML
    file.write("<h2>Gráfico de Correlación de Pearson</h2>")
    file.write(html_fig)
