//using static Android.Provider.UserDictionary;
using System.ComponentModel;
namespace TDMPW_412_3P_PR01;

//todo: agregar imágenes
//todo: poner mensajito de intentalo de nuevo, error, correcto
//todo: colores entry contorno
//todo: checar puntos y errores posición

public partial class MainPage : ContentPage
{
    Pregunta p1 = new Pregunta("¿Cuál es el elemento químico con el símbolo \"Fe\"?", "hierro", "ciencia.png");
    Pregunta p2 = new Pregunta("¿En qué año comenzó la Segunda Guerra Mundial?", "1939", "hector.png");
    Pregunta p3 = new Pregunta("¿Qué deporte se juega con una pelota y una raqueta en una cancha dividida en dos mitades?", "tenis", "bonzo.png");
    Pregunta p4 = new Pregunta("¿Cómo se llama la protagonista femenina de la serie \"Friends\"?", "rachel", "pop.png");
    Pregunta p5 = new Pregunta("¿Quién pintó la Mona Lisa?", "leonardo da vinci", "tina.png");
    Pregunta p6 = new Pregunta("¿Cuál es el país más grande del mundo por superficie?", "rusia", "tito.png");
    Pregunta p7 = new Pregunta("¿Cuál es la capital de Australia?", "canberra", "tito.png");
    Pregunta p8 = new Pregunta("¿Qué órgano del cuerpo humano bombea la sangre?", "corazón", "ciencia.png");
    Pregunta p9 = new Pregunta("¿En qué año se llevó a cabo la Revolución Francesa?", "1789", "hector.png");
    Pregunta p10 = new Pregunta("¿Cuál es el nombre del actor que interpreta a Thor en las películas del Universo Cinematográfico de Marvel?", "chris hemsworth", "pop.png");

    Pregunta p11 = new Pregunta("¿Cuál es el proceso por el cual las plantas convierten la luz solar en energía?", "fotosíntesis", "ciencia.png");
    Pregunta p12 = new Pregunta("¿En qué año se firmó la Declaración de Independencia de los Estados Unidos?", "1776", "hector.png");
    Pregunta p13 = new Pregunta("¿Cuál es el deporte más popular en la India?", "cricket", "bonzo.png");
    Pregunta p14 = new Pregunta("¿Cuál es el nombre del superhéroe que interpreta Robert Downey Jr. en el Universo Cinematográfico de Marvel?", "iron man", "pop.png");
    Pregunta p15 = new Pregunta("¿Cuál es la técnica artística que utiliza pequeñas piezas de vidrio de colores para crear imágenes?", "mosaico", "tina.png");
    Pregunta p16 = new Pregunta("¿Cuál es el país más grande del mundo por superficie?", "rusia", "tito.png");
    Pregunta p17 = new Pregunta("¿Cuál es el país más poblado del mundo?", "china", "tito.png");
    Pregunta p18 = new Pregunta("¿En qué deporte se utiliza un palo llamado \"putter\"?", "golf", "bonzo.png");
    Pregunta p19 = new Pregunta("¿Cuál es el planeta más cercano al Sol en nuestro sistema solar?", "mercurio", "ciencia.png");
    Pregunta p20 = new Pregunta("¿Cuál es la capital de Canadá?", "ottawa", "tito.png");
    List<Pregunta> preguntas = new List<Pregunta>();
    List<Pregunta> preguntasPartida = new List<Pregunta>();

    int puntos = 0;
    int errores = 0;
    int intentos = 0;
    int contadorPreguntas = 0;
    bool seInsertoRespuesta = false;

    private Pregunta preguntaActual;
    private string textoPregunta = "°  °  °";
    private string imgPregunta = "willy.png";
    private string textoBotonPrincipal = "Siguiente";
    private string textoBotonInicio = "Jugar";

    public int Errores
    {
        get => errores;
        set
        {
            errores = value;
            OnPropertyChanged();
        }
    }

    public int Puntos
    {
        get => puntos;
        set
        {
            puntos = value;
            OnPropertyChanged();
        }
    }

    public string TextoBotonPrincipal
    {
        get => textoBotonPrincipal;
        set
        {
            textoBotonPrincipal = value;
            OnPropertyChanged();
        }
    }

    public string TextoBotonInicio
    {
        get => textoBotonInicio;
        set
        {
            textoBotonInicio = value;
            OnPropertyChanged();
        }
    }

    public string TextoPregunta
    {
        get => textoPregunta;
        set
        {
            textoPregunta = value;
            OnPropertyChanged();
        }
    }

    public string ImgPregunta
    {
        get => imgPregunta;
        set
        {
            imgPregunta = value;
            OnPropertyChanged();
        }
    }

    public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
    }

    private void IniciarJuego()
    {
        intentos = 0;
        Errores = 0;
        Puntos = 0;
        contadorPreguntas = 0;

        preguntas.Clear();
        preguntasPartida.Clear();

        preguntas.Add(p1);
        preguntas.Add(p2);
        preguntas.Add(p3);
        preguntas.Add(p4);
        preguntas.Add(p5);
        preguntas.Add(p6);
        preguntas.Add(p7);
        preguntas.Add(p8);
        preguntas.Add(p9);
        preguntas.Add(p10);
        preguntas.Add(p11);
        preguntas.Add(p12);
        preguntas.Add(p13);
        preguntas.Add(p14);
        preguntas.Add(p15);
        preguntas.Add(p16);
        preguntas.Add(p17);
        preguntas.Add(p18);
        preguntas.Add(p19);
        preguntas.Add(p20);

        GenerarListaActual();
    }

    private void GenerarListaActual()
    {
        Random random = new Random();

        while (preguntasPartida.Count < 6)
        {
            int indicePreguntaElegida = random.Next(0, preguntas.Count);
            Pregunta preguntaElegida = preguntas[indicePreguntaElegida];

            preguntasPartida.Add(preguntaElegida);
            preguntas.RemoveAt(indicePreguntaElegida);

        }
    }

    void btnInicio_Clicked(System.Object sender, System.EventArgs e)
    {
        IniciarJuego();

        PickPregunta();

        btnInicio.IsVisible = false;
        btnPrincipal.IsVisible = true;

        txtRespuesta.IsVisible = true;
        txtRespuesta.Background = Color.FromHex("#4ba4d2");
        img1.IsVisible = false;
        img2.IsVisible = false;
        img3.IsVisible = false;
    }

    private void PickPregunta()
    {
        preguntaActual = preguntasPartida[contadorPreguntas];
        TextoPregunta = preguntasPartida[contadorPreguntas].pregunta;
        ImgPregunta = preguntasPartida[contadorPreguntas].imagen;
        contadorPreguntas++;
    }

    void btnPrincipal_Clicked(System.Object sender, System.EventArgs e)
    {

        ChecarRespuestaCorrecta();

        if (JuegoGanado() || JuegoPerdido())
        {
            btnPrincipal.IsVisible = false;
            btnInicio.IsVisible = true;

            TextoBotonInicio = "Reiniciar";
            img1.IsVisible = true;
            img2.IsVisible = true;
            img3.IsVisible = true;


            txtRespuesta.IsVisible = false;
            txtRespuesta.BackgroundColor = Color.FromRgba(0,0,0,0);
            

            if (JuegoGanado())
            {
                ImgPregunta = "crown.png";
            }
            else if (JuegoPerdido())
            {
                ImgPregunta = "sword.png";
            }
            
        }
        else
        {
            if (intentos == 0 && seInsertoRespuesta == true)
            {
                PickPregunta();
            }
        }

        txtRespuesta.Text = "";
    }

    private void ChecarRespuestaCorrecta()
    {

        if (txtRespuesta.Text == "")
        {
            TextoBotonPrincipal = "¡Inserta tu respuesta!";
            seInsertoRespuesta = false;

        }
        else
        {
            seInsertoRespuesta = true;
            if (preguntaActual.respuesta == txtRespuesta.Text.ToLower().Trim())
            {
                intentos = 0;
                Puntos++;
                TextoBotonPrincipal = "Siguiente";
            }
            else
            {
                if (intentos < 1)
                {
                    intentos++;
                    TextoBotonPrincipal = "Inténtalo otra vez...";
                }
                else
                {
                    intentos = 0;
                    TextoBotonPrincipal = "Siguiente";
                    Errores++;
                }
            }
        }
    }

    private bool JuegoGanado()
    {
        if (puntos == 3)
        {
            TextoPregunta = "¡Ganaste!";
            return true;
        }
        return false;
    }

    private bool JuegoPerdido()
    {
        if (errores == 3)
        {
            TextoPregunta = "¡Perdiste!";
            return true;
        }
        return false;
    }


}


