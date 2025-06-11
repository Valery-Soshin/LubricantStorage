namespace LubricantStorage.Core.Entities
{
    /// <summary>
    /// Характеристика масла
    /// </summary>
    public class LubricantСharacteristics 
    {
        /// <summary>
        /// Вязкость при 40°C
        /// </summary>
        public double KinematicViscosity40C { get; set; }

        /// <summary>
        /// Вязкость при 100°C
        /// </summary>
        public double KinematicViscosity100C { get; set; }

        /// <summary>
        /// Индекс вязкости
        /// </summary>
        public int ViscosityIndex { get; set; }

        /// <summary>
        /// Температура застывания (°C)
        /// </summary>
        public double PourPoint { get; set; }

        /// <summary>
        /// Температура вспышки (°C)
        /// </summary>
        public double FlashPoint { get; set; }

        /// <summary>
        /// Температура испарения (°C)
        /// </summary>
        public double EvaporationTemperature { get; set; }

        /// <summary>
        /// Плотность при 15°C (г/см³)
        /// </summary>
        public double Density { get; set; }

        /// <summary>
        /// Кислотное число (TAN)
        /// </summary>
        public double AcidNumber { get; set; }

        /// <summary>
        /// Щелочное число (TBN)
        /// </summary>
        public double BaseNumber { get; set; }

        /// <summary>
        /// Сульфатная зольность (%)
        /// </summary>
        public double SulfatedAshContent { get; set; }

        /// <summary>
        /// Содержание воды(%)
        /// </summary>
        public double WaterContent { get; set; }

        /// <summary>
        /// Содержание загрязнений (%)
        /// </summary>
        public double Contaminants { get; set; }

        /// <summary>
        /// Окислительная стабильность
        /// </summary>
        public double OxidativeStability { get; set; }

        /// <summary>
        /// Аддитивный состав
        /// </summary>
        public string AdditiveComposition { get; set; }

        /// <summary>
        /// Совместимость с материалами
        /// </summary>
        public string MaterialCompatibility { get; set; }

        public override string ToString()
        {
            return $"Вязкость (40°C): {KinematicViscosity40C} cSt, " +
                   $"Вязкость (100°C): {KinematicViscosity100C} cSt, " +
                   $"Индекс вязкости: {ViscosityIndex}, " +
                   $"Температура застывания: {PourPoint}°C, " +
                   $"Температура вспышки: {FlashPoint}°C, " +
                   $"Температура испарения: {EvaporationTemperature}°C, " +
                   $"Плотность: {Density} г/см³, " +
                   $"Кислотное число: {AcidNumber}, " +
                   $"Щелочное число: {BaseNumber}, " +
                   $"Сульфатная зольность: {SulfatedAshContent}%, " +
                   $"Содержание воды: {WaterContent}%, " +
                   $"Загрязнения: {Contaminants}%, " +
                   $"Окислительная стабильность: {OxidativeStability}, " +
                   $"Присадки: {AdditiveComposition}, " +
                   $"Совместимость: {MaterialCompatibility}";
        }
    }
}