using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tienda
{
    public partial class Form1 : Form
    {
        private Nodo raiz;

        public Form1()
        {
            InitializeComponent();
            ConstruirArbol();
        }

        private void ConstruirArbol()
        {
            EspacioEstados tienda = new EspacioEstados("ElekStore");
            Estado tiendaRaiz = tienda.InsertarEstado("ElekStore");
            // Categorías principales
            Estado electronica = tienda.InsertarEstado("Electrónica");
            Estado ropa = tienda.InsertarEstado("Ropa");
            Estado hogar = tienda.InsertarEstado("Hogar");
            Estado deportes = tienda.InsertarEstado("Deportes");
            Estado juguetes = tienda.InsertarEstado("Juguetes");
            Estado belleza = tienda.InsertarEstado("Belleza y Cuidado Personal");

            // Subcategorías de Electrónica
            Estado celulares = tienda.InsertarEstado("Celulares");
            Estado laptops = tienda.InsertarEstado("Laptops");
            Estado televisores = tienda.InsertarEstado("Televisores");
            Estado accesoriosElectronicos = tienda.InsertarEstado("Accesorios Electrónicos");

            // Subcategorías de Ropa
            Estado camisas = tienda.InsertarEstado("Camisas");
            Estado pantalones = tienda.InsertarEstado("Pantalones");
            Estado zapatos = tienda.InsertarEstado("Zapatos");
            Estado chaquetas = tienda.InsertarEstado("Chaquetas");
            Estado vestidos = tienda.InsertarEstado("Vestidos");

            // Subcategorías de Hogar
            Estado muebles = tienda.InsertarEstado("Muebles");
            Estado decoracion = tienda.InsertarEstado("Decoración");
            Estado cocina = tienda.InsertarEstado("Cocina");
            Estado electrodomesticos = tienda.InsertarEstado("Electrodomésticos");

            // Subcategorías de Deportes
            Estado calzadoDeportivo = tienda.InsertarEstado("Calzado Deportivo");
            Estado ropaDeportiva = tienda.InsertarEstado("Ropa Deportiva");
            Estado equiposDeportivos = tienda.InsertarEstado("Equipos Deportivos");

            // Subcategorías de Juguetes
            Estado juegosDeMesa = tienda.InsertarEstado("Juegos de Mesa");
            Estado figurasDeAccion = tienda.InsertarEstado("Figuras de Acción");
            Estado peluches = tienda.InsertarEstado("Peluches");

            // Subcategorías de Belleza y Cuidado Personal
            Estado maquillaje = tienda.InsertarEstado("Maquillaje");
            Estado cuidadoPiel = tienda.InsertarEstado("Cuidado de la Piel");
            Estado perfumes = tienda.InsertarEstado("Perfumes");

            // Relacionar con la raíz de la tienda
            tienda.RelacionarEstados(tiendaRaiz, electronica);
            tienda.RelacionarEstados(tiendaRaiz, ropa);
            tienda.RelacionarEstados(tiendaRaiz, hogar);
            tienda.RelacionarEstados(tiendaRaiz, deportes);
            tienda.RelacionarEstados(tiendaRaiz, juguetes);
            tienda.RelacionarEstados(tiendaRaiz, belleza);

            // Relacionar subcategorías
            tienda.RelacionarEstados(electronica, celulares);
            tienda.RelacionarEstados(electronica, laptops);
            tienda.RelacionarEstados(electronica, televisores);
            tienda.RelacionarEstados(electronica, accesoriosElectronicos);

            tienda.RelacionarEstados(ropa, camisas);
            tienda.RelacionarEstados(ropa, pantalones);
            tienda.RelacionarEstados(ropa, zapatos);
            tienda.RelacionarEstados(ropa, chaquetas);
            tienda.RelacionarEstados(ropa, vestidos);

            tienda.RelacionarEstados(hogar, muebles);
            tienda.RelacionarEstados(hogar, decoracion);
            tienda.RelacionarEstados(hogar, cocina);
            tienda.RelacionarEstados(hogar, electrodomesticos);

            tienda.RelacionarEstados(deportes, calzadoDeportivo);
            tienda.RelacionarEstados(deportes, ropaDeportiva);
            tienda.RelacionarEstados(deportes, equiposDeportivos);

            tienda.RelacionarEstados(juguetes, juegosDeMesa);
            tienda.RelacionarEstados(juguetes, figurasDeAccion);
            tienda.RelacionarEstados(juguetes, peluches);

            tienda.RelacionarEstados(belleza, maquillaje);
            tienda.RelacionarEstados(belleza, cuidadoPiel);
            tienda.RelacionarEstados(belleza, perfumes);

            // Ahora asignamos correctamente la raíz
            raiz = ConvertirAArbol(tiendaRaiz);
        }

        private Nodo ConvertirAArbol(Estado estado)
        {
            Nodo nodo = new Nodo(estado.Nombre);
            foreach (var hijo in estado.Hijos)
            {
                nodo.AgregarHijo(ConvertirAArbol(hijo));
            }
            return nodo;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            Stack<string> recorrido = new Stack<string>();
            List<Nodo> resultados = BuscarDFS(raiz, codigo, recorrido);

            lstRecorrido.Items.Clear();
            foreach (string nodo in recorrido)
            {
                lstRecorrido.Items.Add(nodo);
            }

            if (resultados.Count > 0)
            {
                lblResultado.Text = $"Se encontraron {resultados.Count} resultados: "; 
                foreach (var resultado in resultados)
                {
                    lstRecorrido.Items.Add(resultado.Nombre);
                }
            }
            else
            {
                lblResultado.Text = "No se encontraron coincidencias";
            }
        }

        private List<Nodo> BuscarDFS(Nodo nodo, string codigo, Stack<string> recorrido)
        {
            List<Nodo> encontrados = new List<Nodo>();
            recorrido.Push(nodo.Nombre);

            if (nodo.Nombre.ToLower().Contains(codigo.ToLower()))

            {
                encontrados.Add(nodo);

                foreach (var hijo in nodo.Hijos)
                {
                    encontrados.Add(hijo);
                }
            }
            foreach (var hijo in nodo.Hijos)
            {
                encontrados.AddRange(BuscarDFS(hijo, codigo, recorrido))
;            }
            if (encontrados.Count == 0)
                recorrido.Pop();
            return encontrados;

        }
    }

    public class Nodo
    {
        public string Nombre { get; set; }
        public List<Nodo> Hijos { get; set; }

        public Nodo(string nombre)
        {
            Nombre = nombre;
            Hijos = new List<Nodo>();
        }

        public void AgregarHijo(Nodo hijo)
        {
            Hijos.Add(hijo);
        }
    }

    public class Estado
    {
        public string Nombre { get; set; }
        public List<Estado> Hijos { get; set; }

        public Estado(string nombre)
        {
            Nombre = nombre;
            Hijos = new List<Estado>();
        }

        public void AgregarHijo(Estado hijo)
        {
            Hijos.Add(hijo);
        }
    }

    public class EspacioEstados
    {
        public string Nombre { get; set; }
        public List<Estado> Estados { get; set; }

        public EspacioEstados(string nombre)
        {
            Nombre = nombre;
            Estados = new List<Estado>();
        }

        public Estado InsertarEstado(string nombre)
        {
            Estado estado = new Estado(nombre);
            Estados.Add(estado);
            return estado;
        }

        public void RelacionarEstados(Estado padre, Estado hijo)
        {
            padre.AgregarHijo(hijo);
        }
    }
}
