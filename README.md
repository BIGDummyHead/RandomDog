# RandomDog
Get Random Dogs!

```csharp
Dog randomDog = Dog.Fetch();
Dog dog = Dog.Fetch(breed);
Dog subDog = Dog.Fetch(breed, subBreed);
```

```csharp 

//request a list of all dogs that you can request an image of
DogInfo requestAll = await DogInfo.Request();

foreach (string mainBreeds in requestAll.Doggies)
{
     //Prints a main breed of a dog. Bulldog
     Console.WriteLine(mainBreeds);

     foreach (string subBreed in requestAll.Doggies[mainBreeds])
     {
          //Prints a sub breed of a dog. French
          Console.WriteLine($"{subBreed}");
     }
}

   //Points back to line : 13, this is to save performance.
   DogInfo lastInfo = DogInfo.Requested;
            
```

[Dog Nuget](https://www.nuget.org/packages/RandomDog/1.0.0)
