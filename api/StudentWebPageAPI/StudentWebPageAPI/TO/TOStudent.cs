using System.ComponentModel.DataAnnotations;

namespace StudentWebPageAPI.TO
{
    public class TOStudent
    {
        [Required]
        public String Name { get; set; } = String.Empty;
        [Required]
        public String Email { get; set; } = String.Empty;
        [Required]
        public String CPF { get; set; } = String.Empty;
        [Required]
        public Int64 RA { get; set; }

        //public static EquipamentoDTO DeEntidadeParaDTO(Equipamento equipamento)
        //{
        //    return new EquipamentoDTO
        //    {
        //        EquipamentoId = equipamento.Id,
        //        Nome = equipamento.Nome,
        //        Descricao = equipamento.Descricao,
        //        CustoDiario = equipamento.CustoDiario
        //    };
        //}

    }
}
