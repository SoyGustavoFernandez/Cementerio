using System;

namespace SW.CEMENTERIO.EntityLayer
{
	public class ENT_TA_CEMENTERIO
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ENT_TA_CEMENTERIO class.
		/// </summary>
		public ENT_TA_CEMENTERIO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_CEMENTERIO class.
		/// </summary>
		public ENT_TA_CEMENTERIO(string CEMS_NOMBRES, string CEMS_USUREGISTRO, DateTime CEMD_FECREGISTRO, string CEMS_USUMODIFICA, DateTime CEMD_FECMODIFICA, bool CEMB_ESTADO)
		{
			this.CEMS_NOMBRES = CEMS_NOMBRES;
			this.CEMS_USUREGISTRO = CEMS_USUREGISTRO;
			this.CEMD_FECREGISTRO = CEMD_FECREGISTRO;
			this.CEMS_USUMODIFICA = CEMS_USUMODIFICA;
			this.CEMD_FECMODIFICA = CEMD_FECMODIFICA;
			this.CEMB_ESTADO = CEMB_ESTADO;
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_CEMENTERIO class.
		/// </summary>
		public ENT_TA_CEMENTERIO(int CEMN_IDCEMENTERIO, string CEMS_NOMBRES, string CEMS_USUREGISTRO, DateTime CEMD_FECREGISTRO, string CEMS_USUMODIFICA, DateTime CEMD_FECMODIFICA, bool CEMB_ESTADO)
		{
			this.CEMN_IDCEMENTERIO = CEMN_IDCEMENTERIO;
			this.CEMS_NOMBRES = CEMS_NOMBRES;
			this.CEMS_USUREGISTRO = CEMS_USUREGISTRO;
			this.CEMD_FECREGISTRO = CEMD_FECREGISTRO;
			this.CEMS_USUMODIFICA = CEMS_USUMODIFICA;
			this.CEMD_FECMODIFICA = CEMD_FECMODIFICA;
			this.CEMB_ESTADO = CEMB_ESTADO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the CEMN_IDCEMENTERIO value. 
		/// </summary>
		public int CEMN_IDCEMENTERIO { get; set; }

		/// <summary>
		/// Gets or sets the CEMS_NOMBRES value. 
		/// </summary>
		public string CEMS_NOMBRES { get; set; }

		/// <summary>
		/// Gets or sets the CEMS_USUREGISTRO value. 
		/// </summary>
		public string CEMS_USUREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the CEMD_FECREGISTRO value. 
		/// </summary>
		public DateTime CEMD_FECREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the CEMS_USUMODIFICA value. 
		/// </summary>
		public string CEMS_USUMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the CEMD_FECMODIFICA value. 
		/// </summary>
		public DateTime CEMD_FECMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the CEMB_ESTADO value. 
		/// </summary>
		public bool CEMB_ESTADO { get; set; }

		#endregion
	}
}
