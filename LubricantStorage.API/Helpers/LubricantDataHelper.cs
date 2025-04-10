using LubricantStorage.Core;

namespace LubricantStorage.API.Helpers
{
    public static class LubricantDataHelper
    {
        /// <summary>
        /// Получить тестовые данные для сущности Lubricant
        /// </summary>
        /// <returns></returns>
        public static List<Lubricant> GetTestLubricants()
        {
            return new List<Lubricant>
            {
                new Lubricant
                {
                    Name = "Mobil 1 5W-30 Advanced Full Synthetic",
                    ApplicationType = LubricantApplicationType.Motor,
                    Characteristics = new LubricantСharacteristics
                    {
                        KinematicViscosity40C = 61.7,
                        KinematicViscosity100C = 11.0,
                        ViscosityIndex = 169,
                        PourPoint = -45,
                        FlashPoint = 230,
                        EvaporationTemperature = 200,
                        Density = 0.857,
                        AcidNumber = 1.2,
                        BaseNumber = 8.5,
                        SulfatedAshContent = 0.8,
                        WaterContent = 0.05,
                        Contaminants = 0.01,
                        OxidativeStability = 95,
                        AdditiveComposition = "Детергенты, дисперсанты, антиоксиданты, противоизносные присадки",
                        MaterialCompatibility = "Совместимо с резиновыми уплотнениями, алюминием, сталью"
                    }
                },
                new Lubricant
                {
                    Name = "Castrol EDGE 0W-20 A3/B4",
                    ApplicationType = LubricantApplicationType.Motor,
                    Characteristics = new LubricantСharacteristics
                    {
                        KinematicViscosity40C = 45.3,
                        KinematicViscosity100C = 8.9,
                        ViscosityIndex = 175,
                        PourPoint = -42,
                        FlashPoint = 220,
                        EvaporationTemperature = 195,
                        Density = 0.852,
                        AcidNumber = 1.0,
                        BaseNumber = 7.8,
                        SulfatedAshContent = 0.7,
                        WaterContent = 0.03,
                        Contaminants = 0.02,
                        OxidativeStability = 92,
                        AdditiveComposition = "Молибденовые присадки, антиоксиданты, противоизносные компоненты",
                        MaterialCompatibility = "Совместимо с каталитическими нейтрализаторами"
                    }
                },
                new Lubricant
                {
                    Name = "Shell Spirax S4 TXM 75W-90",
                    ApplicationType = LubricantApplicationType.Transmission,
                    Characteristics = new LubricantСharacteristics
                    {
                        KinematicViscosity40C = 110.5,
                        KinematicViscosity100C = 18.2,
                        ViscosityIndex = 155,
                        PourPoint = -35,
                        FlashPoint = 210,
                        EvaporationTemperature = 180,
                        Density = 0.892,
                        AcidNumber = 0.8,
                        BaseNumber = 5.2,
                        SulfatedAshContent = 0.5,
                        WaterContent = 0.02,
                        Contaminants = 0.03,
                        OxidativeStability = 90,
                        AdditiveComposition = "EP-присадки, противоизносные компоненты, антипенные агенты",
                        MaterialCompatibility = "Совместимо с синхронизаторами и желтыми металлами"
                    }
                },
                new Lubricant
                {
                    Name = "Total Azolla ZS 46",
                    ApplicationType = LubricantApplicationType.Hydraulic,
                    Characteristics = new LubricantСharacteristics
                    {
                        KinematicViscosity40C = 46.0,
                        KinematicViscosity100C = 6.8,
                        ViscosityIndex = 95,
                        PourPoint = -30,
                        FlashPoint = 190,
                        EvaporationTemperature = 160,
                        Density = 0.875,
                        AcidNumber = 0.5,
                        BaseNumber = 4.5,
                        SulfatedAshContent = 0.3,
                        WaterContent = 0.04,
                        Contaminants = 0.02,
                        OxidativeStability = 85,
                        AdditiveComposition = "Антиокислительные, антикоррозионные, антипенные присадки",
                        MaterialCompatibility = "Совместимо с цинковыми покрытиями и уплотнениями NBR"
                    }
                },
                new Lubricant
                {
                    Name = "Lukoil Turbine Oil TP-46",
                    ApplicationType = LubricantApplicationType.Turbine,
                    Characteristics = new LubricantСharacteristics
                    {
                        KinematicViscosity40C = 46.2,
                        KinematicViscosity100C = 6.5,
                        ViscosityIndex = 100,
                        PourPoint = -20,
                        FlashPoint = 200,
                        EvaporationTemperature = 170,
                        Density = 0.880,
                        AcidNumber = 0.3,
                        BaseNumber = 3.5,
                        SulfatedAshContent = 0.1,
                        WaterContent = 0.01,
                        Contaminants = 0.01,
                        OxidativeStability = 98,
                        AdditiveComposition = "Антиоксиданты, ингибиторы коррозии, деэмульгаторы",
                        MaterialCompatibility = "Совместимо с подшипниками скольжения и уплотнениями"
                    }
                }
            };
        }
    }
}
