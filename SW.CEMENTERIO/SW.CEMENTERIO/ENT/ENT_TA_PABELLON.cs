using Microsoft.AspNetCore.Http;
using System;

namespace SW.CEMENTERIO.EntityLayer
{
	public class ENT_TA_PABELLON
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ENT_TA_PABELLON class.
		/// </summary>
		public ENT_TA_PABELLON()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_PABELLON class.
		/// </summary>
		public ENT_TA_PABELLON(int PABN_IDCEMENTERIO, string PABS_NOMBRE, int PABS_TIPO, string PABS_UBICACION, string PABS_USUREGISTRO, DateTime PABD_FECREGISTRO, string PABS_USUMODIFICA, DateTime PABD_FECMODIFICA, bool PABB_ESTADO)
		{
			this.PABN_IDCEMENTERIO = PABN_IDCEMENTERIO;
			this.PABS_NOMBRE = PABS_NOMBRE;
			this.PABS_TIPO = PABS_TIPO;
			this.PABS_UBICACION = PABS_UBICACION;
			this.PABS_USUREGISTRO = PABS_USUREGISTRO;
			this.PABD_FECREGISTRO = PABD_FECREGISTRO;
			this.PABS_USUMODIFICA = PABS_USUMODIFICA;
			this.PABD_FECMODIFICA = PABD_FECMODIFICA;
			this.PABB_ESTADO = PABB_ESTADO;
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_PABELLON class.
		/// </summary>
		public ENT_TA_PABELLON(int PABN_IDPABELLON, int PABN_IDCEMENTERIO, string PABS_NOMBRE, int PABS_TIPO, string PABS_UBICACION, string PABS_USUREGISTRO, DateTime PABD_FECREGISTRO, string PABS_USUMODIFICA, DateTime PABD_FECMODIFICA, bool PABB_ESTADO)
		{
			this.PABN_IDPABELLON = PABN_IDPABELLON;
			this.PABN_IDCEMENTERIO = PABN_IDCEMENTERIO;
			this.PABS_NOMBRE = PABS_NOMBRE;
			this.PABS_TIPO = PABS_TIPO;
			this.PABS_UBICACION = PABS_UBICACION;
			this.PABS_USUREGISTRO = PABS_USUREGISTRO;
			this.PABD_FECREGISTRO = PABD_FECREGISTRO;
			this.PABS_USUMODIFICA = PABS_USUMODIFICA;
			this.PABD_FECMODIFICA = PABD_FECMODIFICA;
			this.PABB_ESTADO = PABB_ESTADO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the PABN_IDPABELLON value. 
		/// </summary>
		public int PABN_IDPABELLON { get; set; }

		/// <summary>
		/// Gets or sets the PABN_IDCEMENTERIO value. 
		/// </summary>
		public int PABN_IDCEMENTERIO { get; set; }

		/// <summary>
		/// Gets or sets the PABS_NOMBRE value. 
		/// </summary>
		public string PABS_NOMBRE { get; set; }

		/// <summary>
		/// Gets or sets the PABS_TIPO value. 
		/// </summary>
		public int PABS_TIPO { get; set; }	// 1: Pabellón		2: Mausoleo

		/// <summary>
		/// Gets or sets the PABS_UBICACION value. 
		/// </summary>
		public string PABS_UBICACION { get; set; }

		/// <summary>
		/// Gets or sets the PABS_USUREGISTRO value. 
		/// </summary>
		public string PABS_USUREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the PABD_FECREGISTRO value. 
		/// </summary>
		public DateTime PABD_FECREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the PABS_USUMODIFICA value. 
		/// </summary>
		public string PABS_USUMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the PABD_FECMODIFICA value. 
		/// </summary>
		public DateTime PABD_FECMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the PABB_ESTADO value. 
		/// </summary>
		public bool PABB_ESTADO { get; set; }

		/// <summary>
		/// Gets or sets the UBICACION value. 
		/// </summary>
		public IFormFile UBICACIONFILE { get; set; }

		#endregion
	}
}
