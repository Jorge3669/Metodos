using System;
internal class Program
{
    //METODO PARA LAS VENTAS DE LA TIENDA Y GENERAR FACTURA 
    public void ventas(int[] codLista, string[] listProduc, double[] Stk, double[] prc, double sbt, double ttl, double ia)
    {
        //INICIAMOS LAS VARABLES QUE USAREMOS EN ESTE METODO, LOS ARRAYS PUEDEN ALMACENAR VALORES UNICAMENTO ENTRE 0 Y 1000
        double[] totales = new double[1000];
        double[] cantidades = new double[1000];
        bool salida=false;
        sbt = 0; ttl = 0; ia = 0;
        int aumento = 0;
        string siNo = "Si";
        int[] codListaCopia = new int[1000];
        string[] listProducCopian = new string[100];
        double[] StkCopia = new double[1000];
        double[] prcCopia = new double[1000];
        //EL SIGUIENTE WHILE SE USA PARA REALIZAR LA COMPRA MIENTRAS SEA NECESARIO.
        //SE REPETIRA CUANDO EL VALOR ALMACENA EN LA VARIABLE siNo SEA IGUAL A si
        do
        {
            //CON EL FOR SIGUIENTE MOSTRAMOS LOS PRODUCTOS EN EXISTENCIA
            Console.WriteLine("Código\t\tProducto\t\tStock");
            for (int i = 0; i <= 6; i++)
            {
                Console.WriteLine(codLista[i] + "\t\t" + listProduc[i] + "\t\t" + Stk[i]);
            }
            Console.Write("Ingresa el código del producto: ");
            int cod = int.Parse(Console.ReadLine());
            //ESTE IF SE USÓ PARA GENEREAR UN MENSAJE DE ERROR, SI EL CODIGO INGRESADO ESTA FUERA DE ENTRE 0 - 7
            if (cod <= 0 || cod > 7)
            {
                Console.WriteLine("/ERROR. INGRESA UN VALOR VÁLIDO");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {

                Console.Write("Ingresa la cantidad que se compró: ");
                double cantidad = double.Parse(Console.ReadLine());
                //ESTE IF SE USÓ PARA GENEREAR UN MENSAJE DE ERROR, SI LA CANTIDAD ES MENOR A 0
                if (cantidad <= 0)
                {
                    Console.WriteLine("/ERROR. INGRESA UN VALOR VÁLIDO");
                    Console.ReadKey();
                    Console.Clear();
                }else if (cantidad > Stk[cod - 1])
                {
                    Console.WriteLine("/ERROR. STOCK INSUFICIENTE");
                    Console.ReadKey();
                    Console.Clear();
                }
                else {
                    //EN ESTE ARRAY ENTRAMOS A LA CANTIDAD EN EL STOCK EXISTENTE DEL CODIGO CORRESPONDIENTE, PARA DISMINUIR LO QUE SE VENDIO
                    Stk[cod - 1] = Stk[cod - 1] - cantidad;
                    //CALCULAMOS EL SUBTOTAL DE LA COMPRA REALIZADA
                    sbt += cantidad * prc[cod - 1];
                    //CREAMOS UN ARRAY DONDE SE ALMACENAN LAS CANTIDADES INGRESADAS DE LA COMPRA
                    cantidades[aumento] = cantidad;
                    //CREAMOS UN ARRAY PARA ALMACENAR LOS TOTALES DE COMPRA QUE SE IMPRIMIRAN EN LA FACTURA
                    totales[aumento] = prc[cod - 1] * cantidad;
                    //PREGUNTA PARA REPETIR EL WHILE
                    Console.WriteLine("Desea hacer otra compra?SI/NO");
                    siNo = Console.ReadLine();
                    Console.ReadKey();
                    Console.Clear();
                    //TRANSFORMAMOS LOS ELEMENTOS DE LA VARIABLE siNo EN MINUSCULAS
                    siNo = siNo.ToLower();
                    if (siNo == "no")
                    {
                        salida = true;
                    }
                    aumento++;
                    //CREAMOS UNA COPIA DE ARRAYS, LOS CUALES ALMACENARAR LOS VALORES PARA MOSTRAR EN LA FACTURA
                    //PARA ALMACENAR EN POSICIONES DESDE CERO, PARA MOSTRARLOS EN LA FACTURA
                    listProducCopian[aumento - 1] = listProduc[cod - 1];
                    codListaCopia[aumento - 1] = codLista[cod - 1];
                    prcCopia[aumento - 1] = prc[cod - 1];
                }
                
                
            }
            
        } while (salida==false);
        ia = sbt * 0.12; //CALCULAMOS EL IVA
        ttl = sbt + ia; //CALCULAMOS EL TOTAL

        //NOS MUESTRA LA HORA Y TIEMPO EXACTO QUE SE EMITIO LA FACTURA
        DateTime now = DateTime.Now;
        //EMPIEZA EL PROCESO DE FACTURAR
        Console.WriteLine("Su compra sera facturada...");
        //RECOLECTA LOS DATOS DEL CLIENTE
        Console.WriteLine("Ingrese nombre del cliente: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese apellido del cliente: ");
        string apellidos = Console.ReadLine();
        Console.WriteLine("Ingrese direccion del cliente: ");
        string direccion = Console.ReadLine();
        Console.WriteLine("NIT para su factura: ");
        string nit = Console.ReadLine();
        Console.ReadKey();
        Console.Clear();

        //MOSTRAMOS LA FACTURA CON LOS DATOS PREVIAMENTE INGRESADOS        
        Console.WriteLine("****************************************FACTURA*****************************************");
        Console.WriteLine("***********************************BOUTIQUE ELVIS-COCHO*********************************");
        Console.WriteLine("Nit: " + nit);
        Console.WriteLine("Nombre del Cliente: " + nombre + " " + apellidos);
        Console.WriteLine("Dirección: " + direccion);
        Console.WriteLine("Fecha: " + now);
        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("Codigo.      Descripcion             Cantidad        Precio/u            Total de compra");
        Console.WriteLine("----------------------------------------------------------------------------------------");
        //FOR QUE MUESTRA LOS DATOS DE LA COMPRA EN LOS ARRAY PREVIAMENTE CREADOS
        for (int i = 0; i < aumento; i++)
        {
            Console.WriteLine(" " + codListaCopia[i] + "\t\t" + listProducCopian[i] + "\t\t" + cantidades[i] + "\t\tQ" + prcCopia[i] + "\t\t     Q" + totales[i]);
        }
        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("Subtotal:                                                                    Q" + sbt);
        Console.WriteLine("IVA por compra 12%:                                                          Q" + ia);
        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("TOTAL:                                                                       Q" + ttl);
        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("                       GRACIAS POR COMPRAR EN BOUTIQUE ELVIS-COCHO");
        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.ReadKey();
        Console.Clear();
    }
    //METODO PARA CONSULTAR LOS DATOS EXISTENTES DEL INVENTARIO
    public void consultar(int[] cdlista, string[] liPro, double[] stk, double[] prc)
    {
        DateTime now = DateTime.Now;
        //MUESTRA LOS PRODUCTOS QUE PUEDEN O NO HABER EN EXISTENCIA
        Console.WriteLine("INVENTARIO ACTUAL");
        int codigoProd = 0;
        Console.WriteLine("Cod.         Producto");
        Console.WriteLine(" 1           Blusa");
        Console.WriteLine(" 2           Pantalon Mujer");
        Console.WriteLine(" 3           Vestido");
        Console.WriteLine(" 4           Falda");
        Console.WriteLine(" 5           Playera");
        Console.WriteLine(" 6           Camisa");
        Console.WriteLine(" 7           Pantalon Hombre");
        Console.WriteLine("\nIngrese codigo de producto: ");
        codigoProd = int.Parse(Console.ReadLine());
        Console.Clear();
        //SI EL CODIGO INGRESADO NO ESTA DENTRO DE LOS ANTERIORES MUESTRA EL SIGUIENTE MENSAJE
        if (codigoProd <= 0 || codigoProd > 7)
        {
            Console.Clear();
            Console.WriteLine("Codigo no existente");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            //SI EL CODIGO ESTA EN EL RANGO ADECUADO MUESTRA:
            //CODIGO        PRODUCTO        STOCK       PRECIO
            Console.WriteLine("ULTIMA ACTUALIZACIÓN: " + now);
            Console.WriteLine("Código\t\tProducto\t\tStock\t\tPrecio");
            Console.WriteLine(cdlista[codigoProd - 1] + "\t\t" + liPro[codigoProd - 1] + "\t\t" + stk[codigoProd - 1] + "\t\tQ" + prc[codigoProd - 1]);
            Console.ReadKey();
            Console.Clear();
        }
    }
    //METODO PARA AUMENTAR STOCK
    public void agregarStock(int[] codLista, string[] listProduc, double[] Stk)
    {
        //MUESTRA EL INVENTARIO DE LA TIENDA
        Console.WriteLine("Código\t\tProducto\t\tStock");
        for (int i = 0; i <= 6; i++)
        {
            Console.WriteLine(codLista[i] + "\t\t" + listProduc[i] + "\t\t" + Stk[i]);
        }
        //SE INGRESA EL CODIGO DE PRODUCTO AL QUE SE LE VA AUMENTOS EL STOCK
        Console.Write("Ingresa el código del producto: ");
        int cod = int.Parse(Console.ReadLine());
        if (cod <= 0 || cod > 7)
        {
            //MENSAJE SI NO CUMPLE LOS PARAMETROS
            Console.WriteLine("/ERROR. INGRESA UN VALOR VÁLIDO");
        }
        else
        {
            //DISMINUYE LA CANTIDAD INGRESADA DEL STOCK EN EL INVENTARIO
            Console.Write("Ingresa la cantidad que se compró: ");
            double cantidad = double.Parse(Console.ReadLine());
            if (cantidad <= 0)
            {
                Console.WriteLine("/ERROR. INGRESA UN VALOR VÁLIDO");
            }

            Stk[cod - 1] = Stk[cod - 1] + cantidad;
        }
        Console.ReadKey();
        Console.Clear();
    }
    //METODO PARA PODER ENTRAR AL PROGRAMA (LOGIN)
    public void login(string usuarioLogin, string contraseñaLogin)
    {
        //doWhile SE REPITE MIESTRA EL USUARIO Y CONTRASEÑA SEAN INCORRECTAS
        do
        {
            //SOLICITA USUARIO Y CONTRASEÑA
            Console.Clear();
            Console.WriteLine("==============  --LOGIN--  ===============");
            Console.WriteLine("");
            Console.WriteLine(" INGRESE SU USUARIO: ");
            usuarioLogin = (Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine(" INGRESE SU CONTRASEÑA: ");
            contraseñaLogin = (Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("ENTER para aceptar...");
            Console.ReadKey();
            Console.Clear();
            //CONDICION IF, SI EL USUARIO ES INCORRECTO
            if (usuarioLogin != "Analisis" && contraseñaLogin == "Um.g##")
            {
                Console.WriteLine("USUARIO INCORRECTO");
                Console.ReadKey();
            }
            //CONDICION SI LA CONTRASEÑA ES INCONRRECTA
            else if (usuarioLogin == "Analisis" && contraseñaLogin != "Um.g##")
            {
                Console.WriteLine("CONTRASEÑA INCORRECTA");
                Console.ReadKey();
            }
            //CONDICION SI EL USUARIO Y LA CONTRASEÑA SON INCORRECTAS
            else if (usuarioLogin != "Analisis" && contraseñaLogin != "Um.g##")
            {
                Console.WriteLine("USUARIO Y CONTRASEÑA INCORRECTA");
                Console.ReadKey();
            }
        } while (usuarioLogin != "Analisis" || contraseñaLogin != "Um.g##");
    }
    //INICA EL CODIGO
    public static void Main(string[] args)
    {
        //VARIABLES GLOBALES
        double subtotal = 0, total = 0, iva = 0;
        int i = 0;
        string[] lista_productos = new string[] { "Blusa\t", "Pantalón Mujer", "Vestido\t", "Falda\t", "Playera\t", "Camisa\t", "Pantalón Hombre" };
        int[] codigo_lista = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        double[] stock = new double[] { 1500, 2000, 1250, 1300, 2000, 1750, 2500 };
        double[] precios = new double[] { 50, 200, 125, 75, 60, 90, 100 };

        //CREAMOS OBJETO DE LA CLASE PROGRAM PARA PODER LLAMAR LOS METODOS ANTERIORES
        Program objeto = new Program();
        string usuario = "";
        string contraseña = "";
        int op1 = 0, op2 = 0, op3 = 0;
        //USANDO EL METODO LOGIN
        objeto.login(usuario, contraseña);

        do
        {
            Console.Clear();
            Console.WriteLine("BIENVENIDO\n");
            Console.WriteLine("MENÚ PRINCIPAL");
            Console.WriteLine("1. Inventario");
            Console.WriteLine("2. Ventas");
            Console.WriteLine("3. Salir");
            Console.WriteLine("Seleccione una opción");
            op1 = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (op1)
            {
                case 1:
                    do
                    {
                        Console.WriteLine("INVENTARIO");
                        Console.WriteLine("4. Agregar");
                        Console.WriteLine("5. Consultar");
                        Console.WriteLine("6. Salir");
                        Console.WriteLine("Seleccione una opción");
                        op2 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (op2 == 4 || op2 == 5 || op2 == 6)
                        {
                            Console.WriteLine("Opcion " + op2 + " selecciona");
                            Console.Write("Enter para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Opcion no existente");
                            Console.WriteLine("Seleccione una opcion correcta");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        switch (op2)
                        {
                            case 4:
                                Console.WriteLine("--------------------------------------------");
                                Console.WriteLine("                  AGREGAR");
                                Console.WriteLine("--------------------------------------------");
                                objeto.agregarStock(codigo_lista, lista_productos, stock);
                                break;

                            case 5:
                                Console.WriteLine("--------------------------------------------");
                                Console.WriteLine("                  CONSULTAR");
                                Console.WriteLine("--------------------------------------------");
                                objeto.consultar(codigo_lista, lista_productos, stock, precios);
                                break;
                            case 6:
                                Console.WriteLine("Presione Enter para Salir");
                                Console.ReadKey();
                                break;
                        }
                    } while (op2 != 6);
                    break;
                case 2:
                    Console.WriteLine("INVENTARIO");
                    Console.WriteLine("7. Ventas");
                    Console.WriteLine("8. Salir");
                    Console.WriteLine("Seleccione una opción");
                    op3 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (op3)
                    {
                        case 7:
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("                  VENTAS");
                            Console.WriteLine("--------------------------------------------");
                            objeto.ventas(codigo_lista, lista_productos, stock, precios, subtotal, total, iva);
                            break;

                        case 9:
                            Console.WriteLine("Presione Enter para Salir");
                            Console.ReadKey();
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("GRACIAS POR USAR NUESTRA APLICACION");
                    Console.ReadKey();
                    break;
            }
            if (op1 == 1 || op1 == 2 || op1 == 3)
            {

            }
            else
            {
                Console.WriteLine("Seleccione una opcion correcta");
                Console.ReadKey();
                Console.Clear();
            }
        } while (op1 != 3);
    }
}
