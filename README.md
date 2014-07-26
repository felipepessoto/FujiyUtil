FujiyUtil
=========
With this package you get data from cache or calling your method writing just one line of code.

Usually you do this(for ValueTypes, but Ref Types are similar):

decimal price;

var returnFromCache = Cache["CarClassGetPrice" + carId];

if(returnFromCache is decimal)
{
    price = (decimal)returnFromCache;
}
else
{
    price = GetPrice(carId);
    Cache["CarClassGetPrice" + carId] = price;
}

With Fujiy.Util you just write:

decimal price = CacheHelper.FromCacheOrExecute(() => myObj.GetPrice(carId));
