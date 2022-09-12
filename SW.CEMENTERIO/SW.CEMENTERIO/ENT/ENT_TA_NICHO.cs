using System;

namespace SW.CEMENTERIO.EntityLayer
{
	public class ENT_TA_NICHO : ENT_TA_PABELLON
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ENT_TA_NICHO class.
		/// </summary>
		public ENT_TA_NICHO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_NICHO class.
		/// </summary>
		public ENT_TA_NICHO(string NICS_CODNICHO, int NICB_ESTADONICHO, int NICB_NUMDIF, int NICN_IDPABELLON, string NICS_USUREGISTRO, DateTime NICD_FECREGISTRO, string NICS_USUMODIFICA, DateTime NICD_FECMODIFICA, bool NICB_ESTADO)
		{
			this.NICS_CODNICHO = NICS_CODNICHO;
			this.NICB_ESTADONICHO = NICB_ESTADONICHO;
			this.NICB_NUMDIF = NICB_NUMDIF;
			this.NICN_IDPABELLON = NICN_IDPABELLON;
			this.NICS_USUREGISTRO = NICS_USUREGISTRO;
			this.NICD_FECREGISTRO = NICD_FECREGISTRO;
			this.NICS_USUMODIFICA = NICS_USUMODIFICA;
			this.NICD_FECMODIFICA = NICD_FECMODIFICA;
			this.NICB_ESTADO = NICB_ESTADO;
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_NICHO class.
		/// </summary>
		public ENT_TA_NICHO(int NICN_IDNICHO, string NICS_CODNICHO, int NICB_ESTADONICHO, int NICB_NUMDIF, int NICN_IDPABELLON, string NICS_USUREGISTRO, DateTime NICD_FECREGISTRO, string NICS_USUMODIFICA, DateTime NICD_FECMODIFICA, bool NICB_ESTADO)
		{
			this.NICN_IDNICHO = NICN_IDNICHO;
			this.NICS_CODNICHO = NICS_CODNICHO;
			this.NICB_ESTADONICHO = NICB_ESTADONICHO;
			this.NICB_NUMDIF = NICB_NUMDIF;
			this.NICN_IDPABELLON = NICN_IDPABELLON;
			this.NICS_USUREGISTRO = NICS_USUREGISTRO;
			this.NICD_FECREGISTRO = NICD_FECREGISTRO;
			this.NICS_USUMODIFICA = NICS_USUMODIFICA;
			this.NICD_FECMODIFICA = NICD_FECMODIFICA;
			this.NICB_ESTADO = NICB_ESTADO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the NICN_IDNICHO value. 
		/// </summary>
		public int NICN_IDNICHO { get; set; }

		/// <summary>
		/// Gets or sets the NICS_CODNICHO value. 
		/// </summary>
		public string NICS_CODNICHO { get; set; }

		/// <summary>
		/// Gets or sets the NICB_ESTADONICHO value. 
		/// </summary>
		public int NICB_ESTADONICHO { get; set; }

		/// <summary>
		/// Gets or sets the NICB_NUMDIF value. 
		/// </summary>
		public int NICB_NUMDIF { get; set; }

		/// <summary>
		/// Gets or sets the NICN_IDPABELLON value. 
		/// </summary>
		public int NICN_IDPABELLON { get; set; }

		/// <summary>
		/// Gets or sets the NICS_USUREGISTRO value. 
		/// </summary>
		public string NICS_USUREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the NICD_FECREGISTRO value. 
		/// </summary>
		public DateTime NICD_FECREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the NICS_USUMODIFICA value. 
		/// </summary>
		public string NICS_USUMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the NICD_FECMODIFICA value. 
		/// </summary>
		public DateTime NICD_FECMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the NICB_ESTADO value. 
		/// </summary>
		public bool NICB_ESTADO { get; set; }

		#endregion
	}
}
