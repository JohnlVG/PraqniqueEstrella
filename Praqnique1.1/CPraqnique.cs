using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Policy;

namespace Praqnique1._1
{
    class CPraqnique
    {
        private float mSide, mApothem, mSegmentB, mAngle1;


        // Datos miembro que operan con el modo gráfico.
        private Graphics mGraph;
        private Pen mPen;
        private const float SF = 10;

        //Octagono Interior
        private PointF mA, mB, mC, mD, mE, mF, mG, mH; //mP1,...,mP8
        //Estrella Interna 1
        private PointF P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16;
        //Sombra -  Estrella Interna 1
        private PointF PS1, PS2, PS3, PS4, PS5, PS6, PS7, PS8;

        //Estrella Interna 2
        private PointF PE1, PE2, PE3, PE4, PE5, PE6, PE7, PE8, PE9, PE10, PE11, PE12, PE13, PE14, PE15, PE16;
        //Sombra -  Estrella Interna 2
        private PointF PES1, PES2, PES3, PES4, PES5, PES6, PES7, PES8;

        //Sombra -  Estrella Externa
        private PointF PSE1, PSE2, PSE3, PSE4, PSE5, PSE6, PSE7, PSE8;

        //Vértices del Hexadecágono
        private PointF PH1, PH2, PH3, PH4, PH5, PH6, PH7, PH8;

        private float b;

        // Funciones miembro - Métodos.

        // Constructor por defecto.
        public CPraqnique()
        {
            mSide = 5.0f;
        }
       

        // Función que permite calcular el área del triángulo.
        public void AreaOctagon()
        {
            float mAngle3 = 22.5f * (float)Math.PI / 180.0f;
            mAngle1 = 45.0f * (float)Math.PI / 180.0f;
            b = mSide * (float)Math.Cos(mAngle1);
            mApothem = (mSide / 2.0f) / (float)Math.Tan(mAngle3);

        }

        // Función que permite imprimir el perímetro y el área del triángulo.


        // Función que permite inicializar los datos y controles que operan en 
        // la GUI del triángulo.
        public void InitializeData(PictureBox picCanvas)
        {
            mSide = 0.0f;
            picCanvas.Refresh();
        }

        public void ReadData(TextBox txtSideSide)
        {
            try
            {
                mSide = float.Parse(txtSideSide.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no válido...");
            }
        }

        public void PlotAxis(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black);
            // Eje horizontal - eje x (paralelo al ancho-width del picCanvas).
            mGraph.DrawLine(mPen, 0, 150, 400, 150);
            // Eje vertical - eje y (paralelo al largo-height del picCanvas).
            mGraph.DrawLine(mPen, 200, 0, 200, 300);
            // Centro Trasladado Cp(200,150)
        }

        // Función que permite calcular los valores de los ocho vértices del Octágono,
        // utilizando fórmulas de Geometría y Trigonometría.
        private void CalculateVertex()
        {
            //Octagono Interior
            AreaOctagon();
            mA.X = (-1) * (mApothem - b); mA.Y = mApothem;
            mB.X = mApothem - b; mB.Y = mApothem;
            mC.X = mApothem; mC.Y = mSide / 2;
            mD.X = mApothem; mD.Y = (-1) * (mSide / 2);
            mE.X = mApothem - b; mE.Y = (-1) * mApothem;
            mF.X = (-1) * (mApothem - b); mF.Y = (-1) * mApothem;
            mG.X = (-1) * mApothem; mG.Y = (-1) * mSide / 2;
            mH.X = (-1) * mApothem; mH.Y = mSide / 2;
        }

        // Función que permite graficar un Octágono en base a los valores de los ocho 
        // vértices representados por ocho puntos en un plano.
        public void GraphShape1(PictureBox picCanvas)
        {

            CalculateVertex();

            P1.X = mA.X; P1.Y = mA.Y;
            P2.X = 0; P2.Y = (mSide / 2);
            P3.X = mB.X; P3.Y = mB.Y;
            P4.X = b / 2; P4.Y = b / 2;
            P5.X = mC.X; P5.Y = mC.Y;
            P6.X = mSide / 2; P6.Y = 0;
            P7.X = mD.X; P7.Y = mD.Y;
            P8.X = b / 2; P8.Y = (-1) * b / 2;
            P9.X = mE.X; P9.Y = mE.Y;
            P10.X = 0; P10.Y = (-1) * (mSide / 2);
            P11.X = mF.X; P11.Y = mF.Y;
            P12.X = (-1) * (b / 2); P12.Y = (-1) * (b / 2);
            P13.X = mG.X; P13.Y = mG.Y;
            P14.X = (-1) * (mSide / 2); P14.Y = 0;
            P15.X = mH.X; P15.Y = mH.Y;
            P16.X = (-1) * (b / 2); P16.Y = (b / 2);


            PS1.X = 0; PS1.Y = mApothem - (b / 2);
            PS2.X = mApothem / 2; PS2.Y = mApothem / 2;
            PS3.X = mApothem - (b / 2); PS3.Y = 0;
            PS4.X = mApothem / 2; PS4.Y = (-1) * (mApothem / 2);
            PS5.X = 0; PS5.Y = (-1) * (mApothem - (b / 2));
            PS6.X = (-1) * (mApothem / 2); PS6.Y = (-1) * (mApothem / 2);
            PS7.X = (-1) * (mApothem - (b / 2)); PS7.Y = 0;
            PS8.X = (-1) * (mApothem / 2); PS8.Y = mApothem / 2;

            GraphStar1(picCanvas);
            GraphShadow1(picCanvas);


        }

        public void GraphStar1(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 2);

            mGraph.DrawLine(mPen, P1.X * SF + 200, (-1) * P1.Y * SF + 150, P2.X * SF + 200, (-1) * P2.Y * SF + 150);
            mGraph.DrawLine(mPen, P2.X * SF + 200, (-1) * P2.Y * SF + 150, P3.X * SF + 200, (-1) * P3.Y * SF + 150);
            mGraph.DrawLine(mPen, P3.X * SF + 200, (-1) * P3.Y * SF + 150, P4.X * SF + 200, (-1) * P4.Y * SF + 150);
            mGraph.DrawLine(mPen, P4.X * SF + 200, (-1) * P4.Y * SF + 150, P5.X * SF + 200, (-1) * P5.Y * SF + 150);
            mGraph.DrawLine(mPen, P5.X * SF + 200, (-1) * P5.Y * SF + 150, P6.X * SF + 200, (-1) * P6.Y * SF + 150);
            mGraph.DrawLine(mPen, P6.X * SF + 200, (-1) * P6.Y * SF + 150, P7.X * SF + 200, (-1) * P7.Y * SF + 150);
            mGraph.DrawLine(mPen, P7.X * SF + 200, (-1) * P7.Y * SF + 150, P8.X * SF + 200, (-1) * P8.Y * SF + 150);
            mGraph.DrawLine(mPen, P8.X * SF + 200, (-1) * P8.Y * SF + 150, P9.X * SF + 200, (-1) * P9.Y * SF + 150);
            mGraph.DrawLine(mPen, P9.X * SF + 200, (-1) * P9.Y * SF + 150, P10.X * SF + 200, (-1) * P10.Y * SF + 150);
            mGraph.DrawLine(mPen, P10.X * SF + 200, (-1) * P10.Y * SF + 150, P11.X * SF + 200, (-1) * P11.Y * SF + 150);
            mGraph.DrawLine(mPen, P11.X * SF + 200, (-1) * P11.Y * SF + 150, P12.X * SF + 200, (-1) * P12.Y * SF + 150);
            mGraph.DrawLine(mPen, P12.X * SF + 200, (-1) * P12.Y * SF + 150, P13.X * SF + 200, (-1) * P13.Y * SF + 150);
            mGraph.DrawLine(mPen, P13.X * SF + 200, (-1) * P13.Y * SF + 150, P14.X * SF + 200, (-1) * P14.Y * SF + 150);
            mGraph.DrawLine(mPen, P14.X * SF + 200, (-1) * P14.Y * SF + 150, P15.X * SF + 200, (-1) * P15.Y * SF + 150);
            mGraph.DrawLine(mPen, P15.X * SF + 200, (-1) * P15.Y * SF + 150, P16.X * SF + 200, (-1) * P16.Y * SF + 150);
            mGraph.DrawLine(mPen, P16.X * SF + 200, (-1) * P16.Y * SF + 150, P1.X * SF + 200, (-1) * P1.Y * SF + 150);

        }

        public void GraphShadow1(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            CalculateVertex();
            mPen = new Pen(Color.Black, 2);

            mGraph.DrawLine(mPen, P1.X * SF + 200, (-1) * P1.Y * SF + 150, PS1.X * SF + 200, (-1) * PS1.Y * SF + 150);
            mGraph.DrawLine(mPen, PS1.X * SF + 200, (-1) * PS1.Y * SF + 150, P3.X * SF + 200, (-1) * P3.Y * SF + 150);
            mGraph.DrawLine(mPen, P3.X * SF + 200, (-1) * P3.Y * SF + 150, PS2.X * SF + 200, (-1) * PS2.Y * SF + 150);
            mGraph.DrawLine(mPen, PS2.X * SF + 200, (-1) * PS2.Y * SF + 150, P5.X * SF + 200, (-1) * P5.Y * SF + 150);
            mGraph.DrawLine(mPen, P5.X * SF + 200, (-1) * P5.Y * SF + 150, PS3.X * SF + 200, (-1) * PS3.Y * SF + 150);
            mGraph.DrawLine(mPen, PS3.X * SF + 200, (-1) * PS3.Y * SF + 150, P7.X * SF + 200, (-1) * P7.Y * SF + 150);
            mGraph.DrawLine(mPen, P7.X * SF + 200, (-1) * P7.Y * SF + 150, PS4.X * SF + 200, (-1) * PS4.Y * SF + 150);
            mGraph.DrawLine(mPen, PS4.X * SF + 200, (-1) * PS4.Y * SF + 150, P9.X * SF + 200, (-1) * P9.Y * SF + 150);
            mGraph.DrawLine(mPen, P9.X * SF + 200, (-1) * P9.Y * SF + 150, PS5.X * SF + 200, (-1) * PS5.Y * SF + 150);
            mGraph.DrawLine(mPen, PS5.X * SF + 200, (-1) * PS5.Y * SF + 150, P11.X * SF + 200, (-1) * P11.Y * SF + 150);
            mGraph.DrawLine(mPen, P11.X * SF + 200, (-1) * P11.Y * SF + 150, PS6.X * SF + 200, (-1) * PS6.Y * SF + 150);
            mGraph.DrawLine(mPen, PS6.X * SF + 200, (-1) * PS6.Y * SF + 150, P13.X * SF + 200, (-1) * P13.Y * SF + 150);
            mGraph.DrawLine(mPen, P13.X * SF + 200, (-1) * P13.Y * SF + 150, PS7.X * SF + 200, (-1) * PS7.Y * SF + 150);
            mGraph.DrawLine(mPen, PS7.X * SF + 200, (-1) * PS7.Y * SF + 150, P15.X * SF + 200, (-1) * P15.Y * SF + 150);
            mGraph.DrawLine(mPen, P15.X * SF + 200, (-1) * P15.Y * SF + 150, PS8.X * SF + 200, (-1) * PS8.Y * SF + 150);
            mGraph.DrawLine(mPen, PS8.X * SF + 200, (-1) * PS8.Y * SF + 150, P1.X * SF + 200, (-1) * P1.Y * SF + 150);

        }

        public void GraphShape2(PictureBox picCanvas)
        {
            mSide = 2 * mSide;
            float mAngle3 = 22.5f * (float)Math.PI / 180.0f;
            mAngle1 = 45.0f * (float)Math.PI / 180.0f;
            b = mSide * (float)Math.Cos(mAngle1);
            mApothem = (mSide / 2.0f) / (float)Math.Tan(mAngle3);

            PE1.X = (-1) * (mApothem - b); PE1.Y = mApothem;
            PE2.X = 0; PE2.Y = (mApothem - b / 2);
            PE3.X = (mApothem - b); PE3.Y = mApothem;
            PE4.X = (mSide / 2) + b / 6; PE4.Y = (mSide / 2) + b / 6;
            PE5.X = mApothem; PE5.Y = mApothem - b;
            PE6.X = (mApothem - b / 2); PE6.Y = 0;
            PE7.X = mApothem; PE7.Y = (-1) * (mApothem - b);
            PE8.X = (mSide / 2) + b / 6; PE8.Y = (-1) * ((mSide / 2) + b / 6);
            PE9.X = mApothem - b; PE9.Y = (-1) * mApothem;
            PE10.X = 0; PE10.Y = (-1) * (mApothem - b / 2);
            PE11.X = (-1) * (mApothem - b); PE11.Y = (-1) * mApothem;
            PE12.X = (-1) * ((mSide / 2) + b / 6); PE12.Y = (-1) * ((mSide / 2) + b / 6);
            PE13.X = (-1) * mApothem; PE13.Y = (-1) * (mApothem - b);
            PE14.X = (-1) * ((mApothem - b / 2)); PE14.Y = 0;
            PE15.X = (-1) * mApothem; PE15.Y = mApothem - b;
            PE16.X = (-1) * ((mSide / 2) + b / 6); PE16.Y = (mSide / 2) + b / 6;

            PES1.X = 0; PES1.Y = 3 * P2.Y;
            PES2.X = 3 * P4.X; PES2.Y = 3 * P4.Y;
            PES3.X = 3 * P6.X; PES3.Y = 3 * P6.Y;
            PES4.X = 3 * P8.X; PES4.Y = 3 * P8.Y;
            PES5.X = 3 * P10.X; PES5.Y = 3 * P10.Y;
            PES6.X = 3 * P12.X; PES6.Y = 3 * P12.Y;
            PES7.X = 3 * P14.X; PES7.Y = 3 * P14.Y;
            PES8.X = 3 * P16.X; PES8.Y = 3 * P16.Y;

            GraphStar2(picCanvas);
            GraphShadow2(picCanvas);

        }

        public void GraphStar2(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 3);

            mGraph.DrawLine(mPen, PE16.X * SF + 200, (-1) * PE16.Y * SF + 150, P15.X * SF + 200, (-1) * P15.Y * SF + 150);
            mGraph.DrawLine(mPen, PE16.X * SF + 200, (-1) * PE16.Y * SF + 150, P1.X * SF + 200, (-1) * P1.Y * SF + 150);
            mGraph.DrawLine(mPen, PE2.X * SF + 200, (-1) * PE2.Y * SF + 150, P1.X * SF + 200, (-1) * P1.Y * SF + 150);
            mGraph.DrawLine(mPen, PE2.X * SF + 200, (-1) * PE2.Y * SF + 150, P3.X * SF + 200, (-1) * P3.Y * SF + 150);
            mGraph.DrawLine(mPen, PE4.X * SF + 200, (-1) * PE4.Y * SF + 150, P3.X * SF + 200, (-1) * P3.Y * SF + 150);
            mGraph.DrawLine(mPen, PE4.X * SF + 200, (-1) * PE4.Y * SF + 150, P5.X * SF + 200, (-1) * P5.Y * SF + 150);
            mGraph.DrawLine(mPen, PE6.X * SF + 200, (-1) * PE6.Y * SF + 150, P5.X * SF + 200, (-1) * P5.Y * SF + 150);
            mGraph.DrawLine(mPen, PE6.X * SF + 200, (-1) * PE6.Y * SF + 150, P7.X * SF + 200, (-1) * P7.Y * SF + 150);
            mGraph.DrawLine(mPen, PE8.X * SF + 200, (-1) * PE8.Y * SF + 150, P7.X * SF + 200, (-1) * P7.Y * SF + 150);
            mGraph.DrawLine(mPen, PE8.X * SF + 200, (-1) * PE8.Y * SF + 150, P9.X * SF + 200, (-1) * P9.Y * SF + 150);
            mGraph.DrawLine(mPen, PE10.X * SF + 200, (-1) * PE10.Y * SF + 150, P9.X * SF + 200, (-1) * P9.Y * SF + 150);
            mGraph.DrawLine(mPen, PE10.X * SF + 200, (-1) * PE10.Y * SF + 150, P11.X * SF + 200, (-1) * P11.Y * SF + 150);
            mGraph.DrawLine(mPen, PE12.X * SF + 200, (-1) * PE12.Y * SF + 150, P11.X * SF + 200, (-1) * P11.Y * SF + 150);
            mGraph.DrawLine(mPen, PE12.X * SF + 200, (-1) * PE12.Y * SF + 150, P13.X * SF + 200, (-1) * P13.Y * SF + 150);
            mGraph.DrawLine(mPen, PE14.X * SF + 200, (-1) * PE14.Y * SF + 150, P13.X * SF + 200, (-1) * P13.Y * SF + 150);
            mGraph.DrawLine(mPen, PE14.X * SF + 200, (-1) * PE14.Y * SF + 150, P15.X * SF + 200, (-1) * P15.Y * SF + 150);

        }

        public void GraphShadow2(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 3);

            mGraph.DrawLine(mPen, PES1.X * SF + 200, (-1) * PES1.Y * SF + 150, P1.X * SF + 200, (-1) * P1.Y * SF + 150);
            mGraph.DrawLine(mPen, PES1.X * SF + 200, (-1) * PES1.Y * SF + 150, P3.X * SF + 200, (-1) * P3.Y * SF + 150);
            mGraph.DrawLine(mPen, PES2.X * SF + 200, (-1) * PES2.Y * SF + 150, P3.X * SF + 200, (-1) * P3.Y * SF + 150);
            mGraph.DrawLine(mPen, PES2.X * SF + 200, (-1) * PES2.Y * SF + 150, P5.X * SF + 200, (-1) * P5.Y * SF + 150);
            mGraph.DrawLine(mPen, PES3.X * SF + 200, (-1) * PES3.Y * SF + 150, P5.X * SF + 200, (-1) * P5.Y * SF + 150);
            mGraph.DrawLine(mPen, PES3.X * SF + 200, (-1) * PES3.Y * SF + 150, P7.X * SF + 200, (-1) * P7.Y * SF + 150);
            mGraph.DrawLine(mPen, PES4.X * SF + 200, (-1) * PES4.Y * SF + 150, P7.X * SF + 200, (-1) * P7.Y * SF + 150);
            mGraph.DrawLine(mPen, PES4.X * SF + 200, (-1) * PES4.Y * SF + 150, P9.X * SF + 200, (-1) * P9.Y * SF + 150);
            mGraph.DrawLine(mPen, PES5.X * SF + 200, (-1) * PES5.Y * SF + 150, P9.X * SF + 200, (-1) * P9.Y * SF + 150);
            mGraph.DrawLine(mPen, PES5.X * SF + 200, (-1) * PES5.Y * SF + 150, P11.X * SF + 200, (-1) * P11.Y * SF + 150);
            mGraph.DrawLine(mPen, PES6.X * SF + 200, (-1) * PES6.Y * SF + 150, P11.X * SF + 200, (-1) * P11.Y * SF + 150);
            mGraph.DrawLine(mPen, PES6.X * SF + 200, (-1) * PES6.Y * SF + 150, P13.X * SF + 200, (-1) * P13.Y * SF + 150);
            mGraph.DrawLine(mPen, PES7.X * SF + 200, (-1) * PES7.Y * SF + 150, P13.X * SF + 200, (-1) * P13.Y * SF + 150);
            mGraph.DrawLine(mPen, PES7.X * SF + 200, (-1) * PES7.Y * SF + 150, P15.X * SF + 200, (-1) * P15.Y * SF + 150);
            mGraph.DrawLine(mPen, PES8.X * SF + 200, (-1) * PES8.Y * SF + 150, P15.X * SF + 200, (-1) * P15.Y * SF + 150);
            mGraph.DrawLine(mPen, PES8.X * SF + 200, (-1) * PES8.Y * SF + 150, P1.X * SF + 200, (-1) * P1.Y * SF + 150);

        }

        public void GraphShape3(PictureBox picCanvas)
        {
            PSE1.X = 0;
            PSE1.Y = mApothem - mApothem / 8;

            PSE2.X = (mSide / 2) + b / 3;
            PSE2.Y = (mSide / 2) + b / 3;

            PSE3.X = mApothem - mApothem / 8;
            PSE3.Y = 0;

            PSE4.X = (mSide / 2) + b / 3;
            PSE4.Y = (-1) * ((mSide / 2) + b / 3);

            PSE5.X = 0;
            PSE5.Y = (-1) * (mApothem - mApothem / 8);

            PSE6.X = (-1) * ((mSide / 2) + b / 3);
            PSE6.Y = (-1) * ((mSide / 2) + b / 3);

            PSE7.X = (-1) * (mApothem - (mApothem / 8));
            PSE7.Y = 0;

            PSE8.X = (-1) * ((mSide / 2) + b / 3);
            PSE8.Y = (mSide / 2) + b / 3;
            GraphStar3(picCanvas);
            GraphShadow3(picCanvas);

        }

        public void GraphStar3(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 3);

            mGraph.DrawLine(mPen, PE1.X * SF + 200, (-1) * PE1.Y * SF + 150, PE2.X * SF + 200, (-1) * PE2.Y * SF + 150);
            mGraph.DrawLine(mPen, PE2.X * SF + 200, (-1) * PE2.Y * SF + 150, PE3.X * SF + 200, (-1) * PE3.Y * SF + 150);
            mGraph.DrawLine(mPen, PE3.X * SF + 200, (-1) * PE3.Y * SF + 150, PE4.X * SF + 200, (-1) * PE4.Y * SF + 150);
            mGraph.DrawLine(mPen, PE4.X * SF + 200, (-1) * PE4.Y * SF + 150, PE5.X * SF + 200, (-1) * PE5.Y * SF + 150);
            mGraph.DrawLine(mPen, PE5.X * SF + 200, (-1) * PE5.Y * SF + 150, PE6.X * SF + 200, (-1) * PE6.Y * SF + 150);
            mGraph.DrawLine(mPen, PE6.X * SF + 200, (-1) * PE6.Y * SF + 150, PE7.X * SF + 200, (-1) * PE7.Y * SF + 150);
            mGraph.DrawLine(mPen, PE7.X * SF + 200, (-1) * PE7.Y * SF + 150, PE8.X * SF + 200, (-1) * PE8.Y * SF + 150);
            mGraph.DrawLine(mPen, PE8.X * SF + 200, (-1) * PE8.Y * SF + 150, PE9.X * SF + 200, (-1) * PE9.Y * SF + 150);
            mGraph.DrawLine(mPen, PE9.X * SF + 200, (-1) * PE9.Y * SF + 150, PE10.X * SF + 200, (-1) * PE10.Y * SF + 150);
            mGraph.DrawLine(mPen, PE10.X * SF + 200, (-1) * PE10.Y * SF + 150, PE11.X * SF + 200, (-1) * PE11.Y * SF + 150);
            mGraph.DrawLine(mPen, PE11.X * SF + 200, (-1) * PE11.Y * SF + 150, PE12.X * SF + 200, (-1) * PE12.Y * SF + 150);
            mGraph.DrawLine(mPen, PE12.X * SF + 200, (-1) * PE12.Y * SF + 150, PE13.X * SF + 200, (-1) * PE13.Y * SF + 150);
            mGraph.DrawLine(mPen, PE13.X * SF + 200, (-1) * PE13.Y * SF + 150, PE14.X * SF + 200, (-1) * PE14.Y * SF + 150);
            mGraph.DrawLine(mPen, PE14.X * SF + 200, (-1) * PE14.Y * SF + 150, PE15.X * SF + 200, (-1) * PE15.Y * SF + 150);
            mGraph.DrawLine(mPen, PE15.X * SF + 200, (-1) * PE15.Y * SF + 150, PE16.X * SF + 200, (-1) * PE16.Y * SF + 150);
            mGraph.DrawLine(mPen, PE16.X * SF + 200, (-1) * PE16.Y * SF + 150, PE1.X * SF + 200, (-1) * PE1.Y * SF + 150);


        }

        public void GraphShadow3(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 3);

            mGraph.DrawLine(mPen, PE1.X * SF + 200, (-1) * PE1.Y * SF + 150, PSE1.X * SF + 200, (-1) * PSE1.Y * SF + 150);
            mGraph.DrawLine(mPen, PSE1.X * SF + 200, (-1) * PSE1.Y * SF + 150, PE3.X * SF + 200, (-1) * PE3.Y * SF + 150);
            mGraph.DrawLine(mPen, PE3.X * SF + 200, (-1) * PE3.Y * SF + 150, PSE2.X * SF + 200, (-1) * PSE2.Y * SF + 150);
            mGraph.DrawLine(mPen, PSE2.X * SF + 200, (-1) * PSE2.Y * SF + 150, PE5.X * SF + 200, (-1) * PE5.Y * SF + 150);
            mGraph.DrawLine(mPen, PE5.X * SF + 200, (-1) * PE5.Y * SF + 150, PSE3.X * SF + 200, (-1) * PSE3.Y * SF + 150);
            mGraph.DrawLine(mPen, PSE3.X * SF + 200, (-1) * PSE3.Y * SF + 150, PE7.X * SF + 200, (-1) * PE7.Y * SF + 150);
            mGraph.DrawLine(mPen, PE7.X * SF + 200, (-1) * PE7.Y * SF + 150, PSE4.X * SF + 200, (-1) * PSE4.Y * SF + 150);
            mGraph.DrawLine(mPen, PSE4.X * SF + 200, (-1) * PSE4.Y * SF + 150, PE9.X * SF + 200, (-1) * PE9.Y * SF + 150);
            mGraph.DrawLine(mPen, PE9.X * SF + 200, (-1) * PE9.Y * SF + 150, PSE5.X * SF + 200, (-1) * PSE5.Y * SF + 150);
            mGraph.DrawLine(mPen, PSE5.X * SF + 200, (-1) * PSE5.Y * SF + 150, PE11.X * SF + 200, (-1) * PE11.Y * SF + 150);
            mGraph.DrawLine(mPen, PE11.X * SF + 200, (-1) * PE11.Y * SF + 150, PSE6.X * SF + 200, (-1) * PSE6.Y * SF + 150);
            mGraph.DrawLine(mPen, PSE6.X * SF + 200, (-1) * PSE6.Y * SF + 150, PE13.X * SF + 200, (-1) * PE13.Y * SF + 150);
            mGraph.DrawLine(mPen, PE13.X * SF + 200, (-1) * PE13.Y * SF + 150, PSE7.X * SF + 200, (-1) * PSE7.Y * SF + 150);
            mGraph.DrawLine(mPen, PSE7.X * SF + 200, (-1) * PSE7.Y * SF + 150, PE15.X * SF + 200, (-1) * PE15.Y * SF + 150);
            mGraph.DrawLine(mPen, PE15.X * SF + 200, (-1) * PE15.Y * SF + 150, PSE8.X * SF + 200, (-1) * PSE8.Y * SF + 150);
            mGraph.DrawLine(mPen, PSE8.X * SF + 200, (-1) * PSE8.Y * SF + 150, PE1.X * SF + 200, (-1) * PE1.Y * SF + 150);

        }

        public void GraphShape4(PictureBox picCanvas)
        {
            PH1.X = 0; PH1.Y = 5.25f * P2.Y;
            PH2.X = 5.25f * P4.X; PH2.Y = 5.25f * P4.Y;
            PH3.X = 5.25f * P6.X; PH3.Y = 5.25f * P6.Y;
            PH4.X = 5.25f * P8.X; PH4.Y = 5.25f * P8.Y;
            PH5.X = 5.25f * P10.X; PH5.Y = 5.25f * P10.Y;
            PH6.X = 5.25f * P12.X; PH6.Y = 5.25f * P12.Y;
            PH7.X = 5.25f * P14.X; PH7.Y = 5.25f * P14.Y;
            PH8.X = 5.25f * P16.X; PH8.Y = 5.25f * P16.Y;

            GraphHexadecagon(picCanvas);
            GraphLines(picCanvas);
        }

        public void GraphLines(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 1);
            mGraph.DrawLine(mPen, PH1.X * SF + 200, (-1) * PH1.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PH2.X * SF + 200, (-1) * PH2.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PH3.X * SF + 200, (-1) * PH3.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PH4.X * SF + 200, (-1) * PH4.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PH5.X * SF + 200, (-1) * PH5.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PH6.X * SF + 200, (-1) * PH6.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PH7.X * SF + 200, (-1) * PH7.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PH8.X * SF + 200, (-1) * PH8.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PE1.X * SF + 200, (-1) * PE1.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PE3.X * SF + 200, (-1) * PE3.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PE5.X * SF + 200, (-1) * PE5.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PE7.X * SF + 200, (-1) * PE7.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PE9.X * SF + 200, (-1) * PE9.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PE11.X * SF + 200, (-1) * PE11.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PE13.X * SF + 200, (-1) * PE13.Y * SF + 150, 200, 150);
            mGraph.DrawLine(mPen, PE15.X * SF + 200, (-1) * PE15.Y * SF + 150, 200, 150);

        }
        public void GraphHexadecagon(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 1);
            mGraph.DrawLine(mPen, PH1.X * SF + 200, (-1) * PH1.Y * SF + 150, PE1.X * SF + 200, (-1) * PE1.Y * SF + 150);
            mGraph.DrawLine(mPen, PH1.X * SF + 200, (-1) * PH1.Y * SF + 150, PE3.X * SF + 200, (-1) * PE3.Y * SF + 150);
            mGraph.DrawLine(mPen, PH2.X * SF + 200, (-1) * PH2.Y * SF + 150, PE3.X * SF + 200, (-1) * PE3.Y * SF + 150);
            mGraph.DrawLine(mPen, PH2.X * SF + 200, (-1) * PH2.Y * SF + 150, PE5.X * SF + 200, (-1) * PE5.Y * SF + 150);
            mGraph.DrawLine(mPen, PH3.X * SF + 200, (-1) * PH3.Y * SF + 150, PE5.X * SF + 200, (-1) * PE5.Y * SF + 150);
            mGraph.DrawLine(mPen, PH3.X * SF + 200, (-1) * PH3.Y * SF + 150, PE7.X * SF + 200, (-1) * PE7.Y * SF + 150);
            mGraph.DrawLine(mPen, PH4.X * SF + 200, (-1) * PH4.Y * SF + 150, PE7.X * SF + 200, (-1) * PE7.Y * SF + 150);
            mGraph.DrawLine(mPen, PH4.X * SF + 200, (-1) * PH4.Y * SF + 150, PE9.X * SF + 200, (-1) * PE9.Y * SF + 150);
            mGraph.DrawLine(mPen, PH5.X * SF + 200, (-1) * PH5.Y * SF + 150, PE9.X * SF + 200, (-1) * PE9.Y * SF + 150);
            mGraph.DrawLine(mPen, PH5.X * SF + 200, (-1) * PH5.Y * SF + 150, PE11.X * SF + 200, (-1) * PE11.Y * SF + 150);
            mGraph.DrawLine(mPen, PH6.X * SF + 200, (-1) * PH6.Y * SF + 150, PE11.X * SF + 200, (-1) * PE11.Y * SF + 150);
            mGraph.DrawLine(mPen, PH6.X * SF + 200, (-1) * PH6.Y * SF + 150, PE13.X * SF + 200, (-1) * PE13.Y * SF + 150);
            mGraph.DrawLine(mPen, PH7.X * SF + 200, (-1) * PH7.Y * SF + 150, PE13.X * SF + 200, (-1) * PE13.Y * SF + 150);
            mGraph.DrawLine(mPen, PH7.X * SF + 200, (-1) * PH7.Y * SF + 150, PE15.X * SF + 200, (-1) * PE15.Y * SF + 150);
            mGraph.DrawLine(mPen, PH8.X * SF + 200, (-1) * PH8.Y * SF + 150, PE15.X * SF + 200, (-1) * PE15.Y * SF + 150);
            mGraph.DrawLine(mPen, PH8.X * SF + 200, (-1) * PH8.Y * SF + 150, PE1.X * SF + 200, (-1) * PE1.Y * SF + 150);

        }
    }
}
