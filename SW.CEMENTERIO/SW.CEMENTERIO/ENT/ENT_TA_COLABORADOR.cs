using System;

namespace SW.CEMENTERIO.EntityLayer
{
	public class ENT_TA_COLABORADOR
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ENT_TA_COLABORADOR class.
		/// </summary>
		public ENT_TA_COLABORADOR()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_COLABORADOR class.
		/// </summary>
		public ENT_TA_COLABORADOR(int COLN_IDCEMENTERIO, string COLS_NOMBRES, string COLS_APEPATERNO, string COLS_APEMATERNO, string COLS_CORREO, string COLS_USUREGISTRO, DateTime COLD_FECREGISTRO, string COLS_USUMODIFICA, DateTime COLD_FECMODIFICA, bool COLB_ESTADO)
		{
			this.COLN_IDCEMENTERIO = COLN_IDCEMENTERIO;
			this.COLS_NOMBRES = COLS_NOMBRES;
			this.COLS_APEPATERNO = COLS_APEPATERNO;
			this.COLS_APEMATERNO = COLS_APEMATERNO;
			this.COLS_CORREO = COLS_CORREO;
			this.COLS_USUREGISTRO = COLS_USUREGISTRO;
			this.COLD_FECREGISTRO = COLD_FECREGISTRO;
			this.COLS_USUMODIFICA = COLS_USUMODIFICA;
			this.COLD_FECMODIFICA = COLD_FECMODIFICA;
			this.COLB_ESTADO = COLB_ESTADO;
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_COLABORADOR class.
		/// </summary>
		public ENT_TA_COLABORADOR(int COLN_IDCOLABORADOR, int COLN_IDCEMENTERIO, string COLS_NOMBRES, string COLS_APEPATERNO, string COLS_APEMATERNO, string COLS_CORREO, string COLS_USUREGISTRO, DateTime COLD_FECREGISTRO, string COLS_USUMODIFICA, DateTime COLD_FECMODIFICA, bool COLB_ESTADO)
		{
			this.COLN_IDCOLABORADOR = COLN_IDCOLABORADOR;
			this.COLN_IDCEMENTERIO = COLN_IDCEMENTERIO;
			this.COLS_NOMBRES = COLS_NOMBRES;
			this.COLS_APEPATERNO = COLS_APEPATERNO;
			this.COLS_APEMATERNO = COLS_APEMATERNO;
			this.COLS_CORREO = COLS_CORREO;
			this.COLS_USUREGISTRO = COLS_USUREGISTRO;
			this.COLD_FECREGISTRO = COLD_FECREGISTRO;
			this.COLS_USUMODIFICA = COLS_USUMODIFICA;
			this.COLD_FECMODIFICA = COLD_FECMODIFICA;
			this.COLB_ESTADO = COLB_ESTADO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the COLN_IDCOLABORADOR value. 
		/// </summary>
		public int COLN_IDCOLABORADOR { get; set; }

		/// <summary>
		/// Gets or sets the COLN_IDCEMENTERIO value. 
		/// </summary>
		public int COLN_IDCEMENTERIO { get; set; }

		/// <summary>
		/// Gets or sets the COLS_NOMBRES value. 
		/// </summary>
		public string COLS_NOMBRES { get; set; }

		/// <summary>
		/// Gets or sets the COLS_APEPATERNO value. 
		/// </summary>
		public string COLS_APEPATERNO { get; set; }

		/// <summary>
		/// Gets or sets the COLS_APEMATERNO value. 
		/// </summary>
		public string COLS_APEMATERNO { get; set; }

		/// <summary>
		/// Gets or sets the COLS_CORREO value. 
		/// </summary>
		public string COLS_CORREO { get; set; }

		/// <summary>
		/// Gets or sets the COLS_USUREGISTRO value. 
		/// </summary>
		public string COLS_USUREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the COLD_FECREGISTRO value. 
		/// </summary>
		public DateTime COLD_FECREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the COLS_USUMODIFICA value. 
		/// </summary>
		public string COLS_USUMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the COLD_FECMODIFICA value. 
		/// </summary>
		public DateTime COLD_FECMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the COLB_ESTADO value. 
		/// </summary>
		public bool COLB_ESTADO { get; set; }

		#endregion
	}
}
