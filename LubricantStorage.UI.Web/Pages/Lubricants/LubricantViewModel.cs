namespace LubricantStorage.UI.Web.Pages.Lubricants
{
    using LubricantStorage.Core;
    using System.ComponentModel.DataAnnotations;

    public class LubricantViewModel
    {
        public string Id { get; set; }

        // Основная информация
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Поле 'Наименование' обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Название не должно превышать 100 символов")]
        public string Name { get; set; }

        [Display(Name = "Тип масла по области применения")]
        [Required(ErrorMessage = "Поле 'Тип масла' обязательно для заполнения")]
        public LubricantApplicationType ApplicationType { get; set; }

        // Характеристики масла
        [Display(Name = "Вязкость при 40°C (мм²/с)")]
        [Required(ErrorMessage = "Поле 'Вязкость при 40°C' обязательно для заполнения")]
        [Range(0, 1000, ErrorMessage = "Значение должно быть между 0 и 1000")]
        public double KinematicViscosity40C { get; set; }

        [Display(Name = "Вязкость при 100°C (мм²/с)")]
        [Required(ErrorMessage = "Поле 'Вязкость при 100°C' обязательно для заполнения")]
        [Range(0, 100, ErrorMessage = "Значение должно быть между 0 и 100")]
        public double KinematicViscosity100C { get; set; }

        [Display(Name = "Индекс вязкости")]
        [Required(ErrorMessage = "Поле 'Индекс вязкости' обязательно для заполнения")]
        [Range(0, 400, ErrorMessage = "Значение должно быть между 0 и 400")]
        public int ViscosityIndex { get; set; }

        // Температурные характеристики
        [Display(Name = "Температура застывания (°C)")]
        [Required(ErrorMessage = "Поле 'Темп. застывания' обязательно для заполнения")]
        [Range(-60, 50, ErrorMessage = "Значение должно быть между -60 и 50")]
        public double PourPoint { get; set; }

        [Display(Name = "Температура вспышки (°C)")]
        [Required(ErrorMessage = "Поле 'Темп. вспышки' обязательно для заполнения")]
        [Range(100, 400, ErrorMessage = "Значение должно быть между 100 и 400")]
        public double FlashPoint { get; set; }

        [Display(Name = "Температура испарения (°C)")]
        [Required(ErrorMessage = "Поле 'Темп. испарения' обязательно для заполнения")]
        [Range(50, 300, ErrorMessage = "Значение должно быть между 50 и 300")]
        public double EvaporationTemperature { get; set; }

        // Физико-химические свойства
        [Display(Name = "Плотность при 15°C (г/см³)")]
        [Required(ErrorMessage = "Поле 'Плотность' обязательно для заполнения")]
        [Range(0.7, 1.2, ErrorMessage = "Значение должно быть между 0.7 и 1.2")]
        public double Density { get; set; }

        [Display(Name = "Кислотное число (TAN)")]
        [Required(ErrorMessage = "Поле 'Кислотное число' обязательно для заполнения")]
        [Range(0, 20, ErrorMessage = "Значение должно быть между 0 и 20")]
        public double AcidNumber { get; set; }

        [Display(Name = "Щелочное число (TBN)")]
        [Required(ErrorMessage = "Поле 'Щелочное число' обязательно для заполнения")]
        [Range(0, 30, ErrorMessage = "Значение должно быть между 0 и 30")]
        public double BaseNumber { get; set; }

        [Display(Name = "Сульфатная зольность (%)")]
        [Required(ErrorMessage = "Поле 'Сульфатная зольность' обязательно для заполнения")]
        [Range(0, 2, ErrorMessage = "Значение должно быть между 0 и 2")]
        public double SulfatedAshContent { get; set; }

        // Состав и свойства
        [Display(Name = "Содержание воды (%)")]
        [Required(ErrorMessage = "Поле 'Содержание воды' обязательно для заполнения")]
        [Range(0, 1, ErrorMessage = "Значение должно быть между 0 и 1")]
        public double WaterContent { get; set; }

        [Display(Name = "Содержание загрязнений (%)")]
        [Required(ErrorMessage = "Поле 'Содержание загрязнений' обязательно для заполнения")]
        [Range(0, 5, ErrorMessage = "Значение должно быть между 0 и 5")]
        public double Contaminants { get; set; }

        [Display(Name = "Окислительная стабильность")]
        [Required(ErrorMessage = "Поле 'Окислительная стабильность' обязательно для заполнения")]
        [Range(0, 100, ErrorMessage = "Значение должно быть между 0 и 100")]
        public double OxidativeStability { get; set; }

        [Display(Name = "Аддитивный состав")]
        [Required(ErrorMessage = "Поле 'Аддитивный состави' обязательно для заполнения")]
        [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
        public string AdditiveComposition { get; set; }

        [Display(Name = "Совместимость с материалами")]
        [Required(ErrorMessage = "Поле 'Совместимость с материалами' обязательно для заполнения")]
        [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
        public string MaterialCompatibility { get; set; }
    }
}