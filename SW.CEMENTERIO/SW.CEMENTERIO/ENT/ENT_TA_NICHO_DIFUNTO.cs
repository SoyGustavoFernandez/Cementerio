using System;

namespace SW.CEMENTERIO.EntityLayer
{
	public class ENT_TA_NICHO_DIFUNTO : ENT_TA_DIFUNTO
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ENT_TA_NICHO_DIFUNTO class.
		/// </summary>
		public ENT_TA_NICHO_DIFUNTO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_NICHO_DIFUNTO class.
		/// </summary>
		public ENT_TA_NICHO_DIFUNTO(int NICDIFN_IDNICHO, int NICDIFN_IDDIFUNTO, string NICDIFS_USUREGISTRO, DateTime NICDIFD_FECREGISTRO, string NICDIFS_USUMODIFICA, DateTime NICDIFD_FECMODIFICA, bool NICDIFB_ESTADO)
		{
			this.NICDIFN_IDNICHO = NICDIFN_IDNICHO;
			this.NICDIFN_IDDIFUNTO = NICDIFN_IDDIFUNTO;
			this.NICDIFS_USUREGISTRO = NICDIFS_USUREGISTRO;
			this.NICDIFD_FECREGISTRO = NICDIFD_FECREGISTRO;
			this.NICDIFS_USUMODIFICA = NICDIFS_USUMODIFICA;
			this.NICDIFD_FECMODIFICA = NICDIFD_FECMODIFICA;
			this.NICDIFB_ESTADO = NICDIFB_ESTADO;
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_NICHO_DIFUNTO class.
		/// </summary>
		public ENT_TA_NICHO_DIFUNTO(int NICDIFN_IDNICHODIFUNTO, int NICDIFN_IDNICHO, int NICDIFN_IDDIFUNTO, string NICDIFS_USUREGISTRO, DateTime NICDIFD_FECREGISTRO, string NICDIFS_USUMODIFICA, DateTime NICDIFD_FECMODIFICA, bool NICDIFB_ESTADO)
		{
			this.NICDIFN_IDNICHODIFUNTO = NICDIFN_IDNICHODIFUNTO;
			this.NICDIFN_IDNICHO = NICDIFN_IDNICHO;
			this.NICDIFN_IDDIFUNTO = NICDIFN_IDDIFUNTO;
			this.NICDIFS_USUREGISTRO = NICDIFS_USUREGISTRO;
			this.NICDIFD_FECREGISTRO = NICDIFD_FECREGISTRO;
			this.NICDIFS_USUMODIFICA = NICDIFS_USUMODIFICA;
			this.NICDIFD_FECMODIFICA = NICDIFD_FECMODIFICA;
			this.NICDIFB_ESTADO = NICDIFB_ESTADO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the NICDIFN_IDNICHODIFUNTO value. 
		/// </summary>
		public int NICDIFN_IDNICHODIFUNTO { get; set; }

		/// <summary>
		/// Gets or sets the NICDIFN_IDNICHO value. 
		/// </summary>
		public int NICDIFN_IDNICHO { get; set; }

		/// <summary>
		/// Gets or sets the NICDIFN_IDDIFUNTO value. 
		/// </summary>
		public int NICDIFN_IDDIFUNTO { get; set; }

		/// <summary>
		/// Gets or sets the NICDIFS_USUREGISTRO value. 
		/// </summary>
		public string NICDIFS_USUREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the NICDIFD_FECREGISTRO value. 
		/// </summary>
		public DateTime NICDIFD_FECREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the NICDIFS_USUMODIFICA value. 
		/// </summary>
		public string NICDIFS_USUMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the NICDIFD_FECMODIFICA value. 
		/// </summary>
		public DateTime NICDIFD_FECMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the NICDIFB_ESTADO value. 
		/// </summary>
		public bool NICDIFB_ESTADO { get; set; }

		#endregion
	}
}
