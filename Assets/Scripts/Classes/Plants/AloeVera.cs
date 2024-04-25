namespace Classes.Plants
{
    public class AloeVera : PlantClass
    {

        public AloeVera()
        {
            
            setPlantName("Aloe Vera");
            setDescription("The Aloe Vera is a very common house plant all across America.\n This plant doesn't need as much water as the average plant but does need an average amount of" +
                           "sunlight.\n This plant prefers Sandy soil and will thrive in medium temperatures!");
            
            setWaterDrainMultiplier(.30); // Doesnt need that much water so it'll drain slower
            
            setSunDrainMultiplier(.40); // Needs average amount of sun
            
            setSunMinRange(40); 
            setWaterMinRange(40);
            
            setSunDecayThresh(getSunMinRange() * .5);
            setWaterDecayThresh(getWaterMinRange() * .5);
            
            setSunMaxRange(80);
            setWaterMaxRange(70);
            
            setSunlightAmount(50); // Default: 50
            setWaterAmount(50); // Default: 50
            
            setGrowing(true);
            
            setStatus(0.01);
            setStatusCap(1f);
            
            setState("Seedling");
            
            setPerferedSoil("Sandy");
            
            setHealthString("Healthy");
            
        }
        
        
        
    }
}