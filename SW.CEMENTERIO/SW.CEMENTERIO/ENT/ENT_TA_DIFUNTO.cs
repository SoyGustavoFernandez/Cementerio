using System;

namespace SW.CEMENTERIO.EntityLayer
{
	public class ENT_TA_DIFUNTO : ENT_TA_NICHO
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ENT_TA_DIFUNTO class.
		/// </summary>
		public ENT_TA_DIFUNTO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_DIFUNTO class.
		/// </summary>
		public ENT_TA_DIFUNTO(int DIFN_IDCEMENTERIO, string DIFS_DNI, string DIFS_NOMBRES, string DIFS_APEPATERNO, string DIFS_APEMATERNO, DateTime DIFD_FECHADEFUNCION, string DIFS_USUREGISTRO, DateTime DIFD_FECREGISTRO, string DIFS_USUMODIFICA, DateTime DIFD_FECMODIFICA, bool DIFB_ESTADO)
		{
			this.DIFN_IDCEMENTERIO = DIFN_IDCEMENTERIO;
			this.DIFS_DNI = DIFS_DNI;
			this.DIFS_NOMBRES = DIFS_NOMBRES;
			this.DIFS_APEPATERNO = DIFS_APEPATERNO;
			this.DIFS_APEMATERNO = DIFS_APEMATERNO;
			this.DIFD_FECHADEFUNCION = DIFD_FECHADEFUNCION;
			this.DIFS_USUREGISTRO = DIFS_USUREGISTRO;
			this.DIFD_FECREGISTRO = DIFD_FECREGISTRO;
			this.DIFS_USUMODIFICA = DIFS_USUMODIFICA;
			this.DIFD_FECMODIFICA = DIFD_FECMODIFICA;
			this.DIFB_ESTADO = DIFB_ESTADO;
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_DIFUNTO class.
		/// </summary>
		public ENT_TA_DIFUNTO(int DIFN_IDDIFUNTO, int DIFN_IDCEMENTERIO, string DIFS_DNI, string DIFS_NOMBRES, string DIFS_APEPATERNO, string DIFS_APEMATERNO, DateTime DIFD_FECHADEFUNCION, string DIFS_USUREGISTRO, DateTime DIFD_FECREGISTRO, string DIFS_USUMODIFICA, DateTime DIFD_FECMODIFICA, bool DIFB_ESTADO)
		{
			this.DIFN_IDDIFUNTO = DIFN_IDDIFUNTO;
			this.DIFS_DNI = DIFS_DNI;
			this.DIFN_IDCEMENTERIO = DIFN_IDCEMENTERIO;
			this.DIFS_NOMBRES = DIFS_NOMBRES;
			this.DIFS_APEPATERNO = DIFS_APEPATERNO;
			this.DIFS_APEMATERNO = DIFS_APEMATERNO;
			this.DIFD_FECHADEFUNCION = DIFD_FECHADEFUNCION;
			this.DIFS_USUREGISTRO = DIFS_USUREGISTRO;
			this.DIFD_FECREGISTRO = DIFD_FECREGISTRO;
			this.DIFS_USUMODIFICA = DIFS_USUMODIFICA;
			this.DIFD_FECMODIFICA = DIFD_FECMODIFICA;
			this.DIFB_ESTADO = DIFB_ESTADO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the DIFN_IDDIFUNTO value. 
		/// </summary>
		public int DIFN_IDDIFUNTO { get; set; }
		
		/// <summary>
		/// Gets or sets the DIFN_IDDIFUNTO value. 
		/// </summary>
		public string DIFS_DNI { get; set; }

		/// <summary>
		/// Gets or sets the DIFN_IDCEMENTERIO value. 
		/// </summary>
		public int DIFN_IDCEMENTERIO { get; set; }

		/// <summary>
		/// Gets or sets the DIFS_NOMBRES value. 
		/// </summary>
		public string DIFS_NOMBRES { get; set; }

		/// <summary>
		/// Gets or sets the DIFS_APEPATERNO value. 
		/// </summary>
		public string DIFS_APEPATERNO { get; set; }

		/// <summary>
		/// Gets or sets the DIFS_APEMATERNO value. 
		/// </summary>
		public string DIFS_APEMATERNO { get; set; }

		/// <summary>
		/// Gets or sets the DIFD_FECHADEFUNCION value. 
		/// </summary>
		public DateTime DIFD_FECHADEFUNCION { get; set; }

		/// <summary>
		/// Gets or sets the DIFS_USUREGISTRO value. 
		/// </summary>
		public string DIFS_USUREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the DIFD_FECREGISTRO value. 
		/// </summary>
		public DateTime DIFD_FECREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the DIFS_USUMODIFICA value. 
		/// </summary>
		public string DIFS_USUMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the DIFD_FECMODIFICA value. 
		/// </summary>
		public DateTime DIFD_FECMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the DIFB_ESTADO value. 
		/// </summary>
		public bool DIFB_ESTADO { get; set; }

		#endregion
	}
}
