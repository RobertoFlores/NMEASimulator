/*  Caracteristicas del Simulador  17 Septiembre de 2012 RFS.
 * 
 *  Incluir la capacidad de crear decodedMessages
 *  
 *  Debe incluir una interfaz grafica, para crear objetivos con las siguientes caracteristicas
	Tipo
	MMSI
	Coordenadas Lat/Lon
	Rumbo
	Velocidad Simulada en Knots (Miles/hr).
 * 
 *  La posibilidad de crear objetivos, que seran almacenados en una lista de objetivos
 *  con la idea de iniciarlos todos desde la lista.
 *  
 *  Visualizar en un grid, cada uno de los objetivos, que estan siendo creados.
 *  
 *  Cada objetivo, debera registrar el timestamp en el que inicio su recorrido.
 *  
 *  Se debe incluir la capacidad de enviar a traves de un socket; la lista de objetivos al integrador, cada 10 segundos
 *  con los nuevos valores, que simulen que el objetivo, esta en movimiento.
 *  
 *  Se debera ver en un grid, las actualizaciones de los objetivos, cada vez que se modifiquen sus parametros.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NMEAUtils;
using System.Threading;
using DataTransport;



namespace Simulator
{
	public partial class Form1 : Form
	{

		BindingList<decodedMessage> listaObjetivos;
		//evento del hilo de simulacion
		private static ManualResetEvent eventoSimulacion = new ManualResetEvent(false);
		//evento del hilo de envio
		private static ManualResetEvent eventoEnvio = new ManualResetEvent(false);
		//creamos un objeto basestation necesario para enviar informacion
		baseStation localBaseStation;
		//retrollamada para ajustar texto Coordenadas
		delegate void SetTextDelegateCoordenadas(position coord, int indiceLista);
		//retrollamada para ajustar texto Rumbo COG
		delegate void SetTextDelegateRumbo(float COG, int indiceLista);
		//0 = desconectado, 1 = conectado
		int SenderState;
		int edoSimulacion;
		public Form1()
		{
			InitializeComponent();
		}

		private void btCerrar_Click(object sender, EventArgs e)
		{
			startStopSender();
			iniciarPararSimulacion();
			this.Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//creamos la lista de objetivos
			listaObjetivos = new BindingList<decodedMessage>();

			//Deshabilitamos el autogenerado de columnas
			dgObjetivos.AutoGenerateColumns = false;

			//generamos la columna del MMSI
			DataGridViewTextBoxColumn mmsiColumna = new DataGridViewTextBoxColumn();
			mmsiColumna.DataPropertyName = "_targetMMSI";
			mmsiColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			mmsiColumna.HeaderText = "       MMSI";
			mmsiColumna.Width = 100;

			//generamos la columna del Nombre
			DataGridViewTextBoxColumn nombreColumna = new DataGridViewTextBoxColumn();
			nombreColumna.DataPropertyName = "_shipName";
			nombreColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			nombreColumna.HeaderText = "Nombre del Objetivo";
			nombreColumna.Width = 160;

			//generamos la columna de la lat
			DataGridViewTextBoxColumn latColumna = new DataGridViewTextBoxColumn();
			latColumna.DataPropertyName = "_lat";
			latColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			latColumna.HeaderText = "Lat";
			latColumna.Width = 80;

			//generamos la columna de la lon
			DataGridViewTextBoxColumn lonColumna = new DataGridViewTextBoxColumn();
			lonColumna.DataPropertyName = "_lon";
			lonColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			lonColumna.HeaderText = "Lon";
			lonColumna.Width = 80;

			//generamos la columna del course
			DataGridViewTextBoxColumn courseColumna = new DataGridViewTextBoxColumn();
			courseColumna.DataPropertyName = "_course";
			courseColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			courseColumna.HeaderText = "Rumbo";
			courseColumna.Width = 70;

			//genramos la columna de la velocidad
			DataGridViewTextBoxColumn speedColumna = new DataGridViewTextBoxColumn();
			speedColumna.DataPropertyName = "_speed";
			speedColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			speedColumna.HeaderText = "Vel";
			speedColumna.Width = 70;

			//agregamos las columnas al grid
			dgObjetivos.Columns.Add(mmsiColumna);
			dgObjetivos.Columns.Add(nombreColumna);
			dgObjetivos.Columns.Add(latColumna);
			dgObjetivos.Columns.Add(lonColumna);
			dgObjetivos.Columns.Add(courseColumna);
			dgObjetivos.Columns.Add(speedColumna);



			dgObjetivos.Rows.Clear();
			//pegamos la lista de objetivos al grid
			dgObjetivos.DataSource = listaObjetivos;
		   //dgObjetivos.ContextMenuStrip = mcListaObjetivos;

			//creamos los datos necesarios para la basestation
			localBaseStation = new baseStation();
			localBaseStation.MMSI = 1234567890;
			localBaseStation.descripcion = "Simulador de Objetivos";
			
		   

		}

		private int findInListByMMSI(BindingList<decodedMessage> lista, Int64 MMSIBuscado) 
		{
			for (int i = 0; i < lista.Count; i++ )
			{
				if (lista[i].MMSI == MMSIBuscado)
				{
					//encontrado
					return i;
				}
			}

			//no encontrado
			return -1;
		
		}
		private bool conversionValidaDouble(String valor) 
		{
			try
			{
				System.Convert.ToDouble(valor);
				return true;
			}
			catch (System.FormatException)
			{
				//MessageBox.Show("El sistema no pudo convertir el valor Ingresado porque no es Numerico");
				return false;
			}
			catch (System.OverflowException)
			{
				//MessageBox.Show("El sistema no pudo convertir el valor Ingresado porque no es Numerico");
				return false;
			}
		}
		private bool conversionValidaInt64(String valor)
		{
			try
			{
				System.Convert.ToInt64(valor);
				return true;
			}
			catch (System.FormatException)
			{
				//MessageBox.Show("El sistema no pudo convertir el valor Ingresado porque no es Numerico ó esta Vacio el Campo");
				return false;
			}
			catch (System.OverflowException)
			{
			   // MessageBox.Show("El sistema no pudo convertir el valor Ingresado porque no es Numerico ó esta Vacio el Campo");
				return false;
			}
		}
		private bool conversionValidaInt16(String valor)
		{
			try
			{
				System.Convert.ToInt16(valor);
				return true;
			}
			catch (System.FormatException)
			{
				//MessageBox.Show("El sistema no pudo convertir el valor Ingresado porque no es Numerico");
				return false;
			}
			catch (System.OverflowException)
			{
				//MessageBox.Show("El sistema no pudo convertir el valor Ingresado porque no es Numerico");
				return false;
			}
		}
		private void btAgregar_Click(object sender, EventArgs e)
		{
			
			//Agregaremos uno a uno los objetivos a la lista
			decodedMessage objetivo = new decodedMessage();
			
		   // MessageBox.Show("Indice" + cbTiposObjetivos.SelectedIndex);

			//Del tipo seleccionado en la lista, le indicamos que tipo de objetivo es a traves de su msgType
			switch (cbTiposObjetivos.SelectedIndex)
			{
				case 0: objetivo.msgType = 1;  //class A
				break;
				case 1: objetivo.msgType = 18; //class B
				break;
				case 2: objetivo.msgType = 9;  //SART
				break; 
				case 3: objetivo.msgType = 21; //AtoN
				break; 
						 
			}

			if (objetivo.msgType > 0)
			{
				//validacion del MMSI
				if (conversionValidaInt64(tbMMSI.Text))
				{
					objetivo.MMSI = System.Convert.ToInt64(tbMMSI.Text);
					//validacion del campo nombre del Objetivo
					if (tbNombre.Text != "")
					{
						objetivo.shipname = tbNombre.Text;
						//validacion del campo latitud
						if ((conversionValidaDouble(tbLatitude.Text) == true) && (tbLatitude.Text != ""))
						{
							objetivo.lat = (float)(System.Convert.ToDouble(tbLatitude.Text));
							//validacion del campo longitud
							if ((conversionValidaDouble(tbLongitud.Text) == true) && (tbLongitud.Text != ""))
							{
								objetivo.lon = (float)(System.Convert.ToDouble(tbLongitud.Text));
								//validacion del campo rumbo
								if (conversionValidaDouble(tbRumbo.Text) && (tbRumbo.Text != ""))
								{
									objetivo.course = (float)(System.Convert.ToDouble(tbRumbo.Text));
									//validacion del campo velocidad
									if (conversionValidaDouble(tbVelocidad.Text) && (tbVelocidad.Text != ""))
									{
										objetivo.speed = (float)(System.Convert.ToDouble(tbVelocidad.Text));
										//inicializamos con un timestamp en el campo lastTime
										//check for the current time stamp
										
										double now = TimeController.timeStamp();

										objetivo.lastTime = now;

										//MessageBox.Show("mas" + now);
										//finalmente, agregamos el objetivo						
										listaObjetivos.Add(objetivo);
										//limpiamos cajas de texto
										tbMMSI.Clear();
										tbNombre.Clear();
										tbLatitude.Clear();
										tbLongitud.Clear();
										tbRumbo.Clear();
										tbVelocidad.Clear();
										//informamos al usuario
										//MessageBox.Show("Objetivo Agregado");
									}
									else
									{
										MessageBox.Show("El campo, Velocidad no es valido, o esta vacio");
										tbVelocidad.Clear();
									}
								}
								else
								{
									MessageBox.Show("El campo, Rumbo no es valido, o esta vacio");
									tbRumbo.Clear();
								}
							}
							else
							{
								MessageBox.Show("El campo, Longitud no es valido, o esta vacio");
								tbLongitud.Clear();
							}
						}
						else
						{
							MessageBox.Show("El campo, Latitud no es valido, ó esta vacio");
							tbLatitude.Clear();
						}
					}
					else
					{
					   MessageBox.Show("El campo, nombre de la Embarcación, no puede estar vacio");
					}

				}
				else
				{
					MessageBox.Show("El campo, MMSI de la Embarcación, no es valido ó esta vacio.");
					tbMMSI.Clear();
				}
			}//de la validacion del combo box
			else 
			{
				
				MessageBox.Show("Seleccione un tipo de Objetivo");
			}//else de la validacion del combo box

		}

		

		/*
		 Calcula la distancia en millas nauticas, teniendo como datos de entrada, la velocidad del objetivo
		 * y el tiempo.
		 */
		
		private float calculaDistanciaMN2(float t_horas, float VelEnNudos) //calcula la dist en millas nauticas 
		{
		  
			float DistEnMillasNaut = VelEnNudos * t_horas;

			return DistEnMillasNaut;

		}

		/*
		 Calcula la distancia en millas nauticas, teniendo como datos de entrada, la velocidad del objetivo
		 * y el tiempo.
		 */
		
		private float calculaDistanciaMN(double lastTime, float VelEnNudos) //calcula la dist en millas nauticas 
		{
			/*
			* Variables
			* velocidad en Nudos (Millas nauticas / h)
			* Distancia en Millas  (Recordar que el extend de la Display prototype, esta en metros)
			* Tiempo en Hrs.
			*
			* V = D/t
			* Primer paso.
			* Tenemos un timestamp de referencia en segundos.
			* Si el timestamp de referencia, es menor que el timestampNow
			* iniciamos calculo de distancia recorrida.
			*	
			*/
			double timestampNow = TimeController.timeStamp();

			double tiempoEnHoras = (timestampNow - lastTime) / 3600;//en Hrs

			float DistEnMillasNaut = VelEnNudos * (float)tiempoEnHoras;

			return DistEnMillasNaut;

		}
		private void envio()//funcion para enviar los objetivos simulados a traves de la red
		{
			TimeController temporizador = new TimeController(5, false);

			WrappedNMEADataSender sender;
			int  integratorServerPort= 12082;
			String integratorServerIpAddress = "192.168.0.17";
			sender = new WrappedNMEADataSender(integratorServerIpAddress, integratorServerPort);
			sender.setBaseStation(localBaseStation);
			sender.Connect();

			while (true) 
			{
				
				if(temporizador.isCycleDone)
				{
					if((listaObjetivos.Count > 0) && (sender.aliveConecction()))
					{
						for (int i = 0; i < listaObjetivos.Count; i++ )
						{
							sender.SendTarget(listaObjetivos[i]);
						}
					}
				}
				
				//esperar evento para detener el hilo
				if (eventoEnvio.WaitOne(0, false) == true)
				{
					sender.Disconnect();
					eventoEnvio.Reset();//reset the event
					break;
				}
			}
		}
		private void simulacion() //funcion donde se simula el movimiento de los objetivos
		{
			
			//timer para controlar el tiempo de sleep del hilo, cada ese tiempo, ejecutara la acción.
			TimeController temporizador = new TimeController(3, false);
			while (true)
			{

				if (temporizador.isCycleDone)
				{

					if (listaObjetivos.Count > 0)
					{
						for (int i = 0; i < listaObjetivos.Count; i++)
						{
							

							//float tiempo = 10;//hrs
							double timestampNow = TimeController.timeStamp();
							double tiempoEnHoras = (timestampNow - listaObjetivos[i].lastTime) / 3600;//en Hrs
							//PONER EL NUEVO TIMESTAMP
							double timestampNow2 = TimeController.timeStamp();
							listaObjetivos[i].lastTime = timestampNow2;
							//distancia en Kilometros
							float distanciaKm = geodesicUtils.nauticalMilesToKilometer(calculaDistanciaMN2((float)tiempoEnHoras, listaObjetivos[i].speed));

							position origen = new position(listaObjetivos[i].lat, listaObjetivos[i].lon);

							position destino = geodesicUtils.FindPointAtDistanceFrom(origen, geodesicUtils.DegreesToRadians(listaObjetivos[i].course), distanciaKm);
							//ajustamos las coordenadas de la nueva posicion
							ajustaCoordenadas(destino, i);
							//ajustamos el nuevo curso o bearing en la nueva posicion.
							ajustaRumbo((float)geodesicUtils.bearingFinal(destino, origen),i);                          
						   
						}//del ciclo for

					}
				}
			   
				//esperar evento para detener el hilo
				if (eventoSimulacion.WaitOne(0, false) == true)
				{
					//just wait until the last thread is done
					//Sleep(500);
					eventoSimulacion.Reset();//reset the event
				   break;
				}
			   
			}
		}
		// delegate void SetTextDelegateRumbo(float COG, int indiceLista);
		private void ajustaRumbo(float COG, int indiceLista)
		{

			if (this.dgObjetivos.InvokeRequired)
			{
				SetTextDelegateRumbo d = new SetTextDelegateRumbo(ajustaRumbo);
				this.Invoke(d, new object[] { COG, indiceLista });
			}
			else
			{
				listaObjetivos[indiceLista].course = COG;
			   
				// this.listaObjetivos[indice].speed = velocidad;
			}
		}
		private void ajustaCoordenadas(position coord, int indiceLista) //funcion para setear la velocidad del grid desde un hilo
		{

			if (this.dgObjetivos.InvokeRequired)
			{
				SetTextDelegateCoordenadas d = new SetTextDelegateCoordenadas(ajustaCoordenadas);
				this.Invoke(d, new object[] { coord, indiceLista });
			}
			else
			{
				listaObjetivos[indiceLista].lat = (float)(coord.lat);
				listaObjetivos[indiceLista].lon = (float)(coord.lon);
				//lbObjetivos.Text = System.Convert.ToString(velocidad);
				// this.listaObjetivos[indice].speed = velocidad;
			}
		}

		
		private void modVelocidad_Click(object sender, EventArgs e)
		{
			//modificacion de la velocidad
			int selectorMod = 1; //modificador de la velocidad 1
			int valor = findInListByMMSI(listaObjetivos, System.Convert.ToInt64(dgObjetivos.CurrentRow.Cells[0].Value));
			//Modificar todos los parametros
			Form f = new frmModDatosObjetivos(listaObjetivos, valor, selectorMod);
			f.ShowDialog();

			/*
			MessageBox.Show("Modificar velocidad");
			double velocidad = 21;

			int valor = findInListByMMSI(listaObjetivos, System.Convert.ToInt64(dgObjetivos.CurrentRow.Cells[0].Value));

			if (valor >= 0)
			{
			   // MessageBox.Show("Inidice  " + valor);

					listaObjetivos[valor].speed = (float)(velocidad);
					MessageBox.Show("Se Cambió la Velocidad");
				
			}*/
		}

		private void modCoordenadas_Click(object sender, EventArgs e)
		{
			//codigo modificacion de coordenadas
		   // MessageBox.Show("Modificar Coordenadas");
			int selectorMod = 2; //modificador de la velocidad 2
			int valor = findInListByMMSI(listaObjetivos, System.Convert.ToInt64(dgObjetivos.CurrentRow.Cells[0].Value));
			//Modificar todos los parametros
			Form f = new frmModDatosObjetivos(listaObjetivos, valor, selectorMod);
			f.ShowDialog();

		}

		private void modRumbo_Click(object sender, EventArgs e)
		{
			//codigo modificacion de rumbo
		   // MessageBox.Show("Modificar Rumbo");
			int selectorMod = 3; //modificador de la velocidad 2
			int valor = findInListByMMSI(listaObjetivos, System.Convert.ToInt64(dgObjetivos.CurrentRow.Cells[0].Value));
			//Modificar todos los parametros
			Form f = new frmModDatosObjetivos(listaObjetivos, valor, selectorMod);
			f.ShowDialog();

		}

		private void modificarTodosLosParametrosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			int selectorMod = 0; //selector de modificacion de prametros del objetivo, todos = 0
			int valor = findInListByMMSI(listaObjetivos, System.Convert.ToInt64(dgObjetivos.CurrentRow.Cells[0].Value));
			//Modificar todos los parametros
			Form f = new frmModDatosObjetivos(listaObjetivos, valor, selectorMod);
			f.ShowDialog();


		}

		private void dgObjetivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectorMod = 0; //selector de modificacion de prametros del objetivo, todos = 0

			int valor = findInListByMMSI(listaObjetivos, System.Convert.ToInt64(dgObjetivos.CurrentRow.Cells[0].Value));
			//Modificar todos los parametros
			Form f = new frmModDatosObjetivos(listaObjetivos, valor, selectorMod);
			f.ShowDialog();
		}

		
		private void lbIniciarSimulacion_Click(object sender, EventArgs e)
		{
			/*
			 * Ciclo para iniciar la animacion de objetivos
			 * los parametros de posicion, velocidad y curso, deben variar de acuerdo a los
			 * parametros ajustables 1x, 2x, 4x, etc.
			 */
			
			//MessageBox.Show("la distancia es : " + Distancia);
			iniciarPararSimulacion();
			
		  
		}

		private void iniciarPararSimulacion()
		{

			if (edoSimulacion == 0)
			{
				//iniciar simulacion
				lbOnOffSimulacion.ForeColor = System.Drawing.Color.Green;
				lbOnOffSimulacion.Text = "ON";
				lbIniciarSimulacion.Text = "Detener";
			   
				//se requiere un hilo y un temporizador
				Thread r = new Thread(simulacion);
				r.Start();
				//cambiamos estado de la bandera
				edoSimulacion = 1;
			}
			else
			{
				//detener simulacion
				lbOnOffSimulacion.ForeColor = System.Drawing.Color.Red;
				lbOnOffSimulacion.Text = "OFF";
				lbIniciarSimulacion.Text = "Iniciar";
				//detener hilo simulacion
				eventoSimulacion.Set();
				//cambiar estado de la bandera
				edoSimulacion = 0;
			}
		}
		private void startStopSender()
		{ 
			
			if (SenderState == 0) //sender esta desconectado
			{

				this.lbOnOffEnvio.ForeColor = System.Drawing.Color.Green;
				this.lbOnOffEnvio.Text = "ON";
				this.btEnviarObjetivos.Text = "Detener";
				//this.lbIniciarEnvio.Text = "Detener";
				
			   
				//iniciar envio
				//se requiere un hilo y un temporizador
				Thread s = new Thread(envio);
				s.Start();

				SenderState = 1;
			}
			else //sender esta conectado. 
			{
				this.lbOnOffEnvio.ForeColor = System.Drawing.Color.Red;
				this.lbOnOffEnvio.Text = "OFF";
				this.btEnviarObjetivos.Text = "Iniciar";
				//parar envio
				eventoEnvio.Set();
				//cambiamos bandera
				SenderState = 0;
			
			}
		}
		

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			startStopSender();
			iniciarPararSimulacion();
		}

		private void btEnviarObjetivos_Click(object sender, EventArgs e)
		{
			startStopSender();
		}
	}
}
