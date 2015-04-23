using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NMEAUtils;

namespace Simulator
{
	public partial class frmModDatosObjetivos : Form
	{
		int selector = 0;
		int indiceLista = 0;//de la lista de objetivos
		BindingList<decodedMessage> listaObjetivos;

		public frmModDatosObjetivos(BindingList<decodedMessage> lista, int indice, int _selector)//constructor modificado
		{
			selector = _selector;
			listaObjetivos = lista;
			indiceLista = indice;
			InitializeComponent();
		}

		private void frmModDatosObjetivos_Load(object sender, EventArgs e)
		{
			//cargamos los datos de la lista en el formulario para modificar los datos
			this.tbMMSI.Text = System.Convert.ToString(listaObjetivos[indiceLista].MMSI);
			this.tbNombre.Text = listaObjetivos[indiceLista].shipname;
			this.tbLatitude.Text = System.Convert.ToString(listaObjetivos[indiceLista].lat);
			this.tbLongitud.Text = System.Convert.ToString(listaObjetivos[indiceLista].lon);
			this.tbRumbo.Text = System.Convert.ToString(listaObjetivos[indiceLista].course);
			this.tbVelocidad.Text = System.Convert.ToString(listaObjetivos[indiceLista].speed);
			//deshabilitamos controles de acuerdo al selector
			if (selector == 0) 
			{
				//solo deshabilitamos el MMSI
				tbMMSI.ReadOnly = true;
			
			}else if(selector == 1)
			{
				//se requiere modificar solo la velocidad, por lo tanto deshabilitamos todos excepto la velocidad
				tbMMSI.ReadOnly = true;
				tbNombre.ReadOnly = true;
				tbLatitude.ReadOnly = true;
				tbLongitud.ReadOnly = true;
				tbRumbo.ReadOnly = true;
			}
			else if (selector == 2)
			{
				//se requiere modificar las coordenadas
				tbMMSI.ReadOnly = true;
				tbNombre.ReadOnly = true;
				tbRumbo.ReadOnly = true;
				tbVelocidad.ReadOnly = true;
  
			}else if(selector == 3)
			{
				//se requiere modificar el rumbo
				tbMMSI.ReadOnly = true;
				tbNombre.ReadOnly = true;
				tbLatitude.ReadOnly = true;
				tbLongitud.ReadOnly = true;
				tbVelocidad.ReadOnly = true;
			}
			   
		}

		private void lbGuardar_Click(object sender, EventArgs e)
		{
			//pasamos los nuevos valores a la lista
			//cargamos los datos de la lista en el formulario para modificar los datos
			if (selector == 0)
			{
				//modificacion de todos los datos
				//validacion del nombre de la embarcacion
				if (tbNombre.Text != "")
				{
					listaObjetivos[indiceLista].shipname = this.tbNombre.Text;
					//validacion de la latitud
					//validacion de las coordenadas
					if ((conversionValidaDouble(tbLatitude.Text) == true) && (tbLatitude.Text != ""))
					{
						//modificar la latitud
						listaObjetivos[indiceLista].lat = (float)(System.Convert.ToDouble(this.tbLatitude.Text));
						//validacion de la longitud
						if ((conversionValidaDouble(tbLongitud.Text) == true) && (tbLongitud.Text != ""))
						{
							listaObjetivos[indiceLista].lon = (float)(System.Convert.ToDouble(this.tbLongitud.Text));

							//validacion del rumbo
							if (conversionValidaDouble(tbRumbo.Text) && (tbRumbo.Text != ""))
							{
								//modificar el rumbo
								listaObjetivos[indiceLista].course = (float)(System.Convert.ToDouble(this.tbRumbo.Text));
								//validacion de la velocidad.
								//validacion de la velocidad modificada                   
								if (conversionValidaDouble(tbVelocidad.Text) && (tbVelocidad.Text != ""))
								{
									//modificar la velocidad
									listaObjetivos[indiceLista].speed = (float)(System.Convert.ToDouble(this.tbVelocidad.Text));
									this.Close();
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
						MessageBox.Show("El campo, Latitud no es valido, o esta vacio");
						tbLatitude.Clear();

					}

				}
				else
				{
					
					MessageBox.Show("El campo, nombre de la Embarcación, no puede estar vacio");
				}
			   
			   
			  
			   
				
			}
			else if (selector == 1) 
			{
				//validacion de la velocidad modificada                   
				if (conversionValidaDouble(tbVelocidad.Text) && (tbVelocidad.Text != ""))
				{
					//modificar la velocidad
					listaObjetivos[indiceLista].speed = (float)(System.Convert.ToDouble(this.tbVelocidad.Text));
					this.Close();
				}
				else
				{
					MessageBox.Show("El campo, Velocidad no es valido, o esta vacio");
					tbVelocidad.Clear();
				}



			}else if(selector == 2)
			{
				//validacion de las coordenadas
				if ((conversionValidaDouble(tbLatitude.Text) == true) && (tbLatitude.Text != ""))
				{
					//modificar la latitud
					listaObjetivos[indiceLista].lat = (float)(System.Convert.ToDouble(this.tbLatitude.Text));
					//validacion de la longitud
					if ((conversionValidaDouble(tbLongitud.Text) == true) && (tbLongitud.Text != ""))
					{
						listaObjetivos[indiceLista].lon = (float)(System.Convert.ToDouble(this.tbLongitud.Text));
						this.Close();
					}
					else
					{
						MessageBox.Show("El campo, Longitud no es valido, o esta vacio");
						tbLongitud.Clear();
					}
				}
				else
				{
					MessageBox.Show("El campo, Latitud no es valido, o esta vacio");
					tbLatitude.Clear();

				}
				
				
			   
			}else if(selector == 3)
			{
				//validaciones del rumbo
				if (conversionValidaDouble(tbRumbo.Text) && (tbRumbo.Text != ""))
				{
					//modificar el rumbo
					listaObjetivos[indiceLista].course = (float)(System.Convert.ToDouble(this.tbRumbo.Text));
					this.Close();
				}
				else
				{
					MessageBox.Show("El campo, Rumbo no es valido, o esta vacio");
					tbRumbo.Clear();
				}
	
			   
			}
			
		}

		//funciones para validacion de datos
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
	}
}
