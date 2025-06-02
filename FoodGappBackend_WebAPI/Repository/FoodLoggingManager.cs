using FoodGappBackend_WebAPI.Models;
using static FoodGappBackend_WebAPI.Utils.Utilities;


namespace FoodGappBackend_WebAPI.Repository
{
    public class FoodLoggingManager
    {
        private readonly BaseRepository<Food> _foodLogRepo;


        public FoodLoggingManager()
        {
            _foodLogRepo = new BaseRepository<Food>();
        }

        public Food GetFoodLogById (int foodLogId)
        {
            return _foodLogRepo.Get(foodLogId);
        }

        public ErrorCode CreateFood(Food food, ref string errMsg)
        {
            if(_foodLogRepo.Create(food, out errMsg) != ErrorCode.Success)
            {
                return ErrorCode.Success;
            }
            return ErrorCode.Error;
        }

    }
}
