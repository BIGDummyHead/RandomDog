# Random Dog

### A wrapper for the [Dog Api](https://dog.ceo/dog-api/) that allows you to use all the features from said API  

_____________________________________________________________________________________________

## Features

```csharp
//get a completly random dog.
Dog randomDog = Dog.Fetch();

//get a completely random dog from a certain breed
Dog dog = Dog.Fetch(breed);

//get a completely random dog from a certain breed and sub-breed
Dog subDog = Dog.Fetch(breed, subBreed);
```

```csharp 

//get all dogs, these are not images.
DogList dogs = DogList.GetAll();

//this represents every single breed of dog
//it contains string[] arrays of their sub-breeds.
AllDog doggies = dogs.Message;

foreach (string sub in doggies.terrier)
{
    //this writes out 24 times.
    Console.WriteLine(sub);
}

//to save on performance, get the last request of this list!
DogList _req = DogList.LastRequested;
            
```

#### There is several methods inside of the DogInfo class, these are self explainatory and have summaries of them.
#### The snippets above just show the basic features and how to use DogList.

## Handling Errors

All classes in the wrapper inherit from the BadRequest. This may sound weird, since you are not always guranteed to get a bad request. 

Take a look at this snippet below that shows you how to handle errors!

```csharp

//get 40 random dog pictures from the breed HOUND, and sub-breed AFGHANz
//notice the error in the sub-breed AFGHAN
DogInfo randomDogs = DogInfo.GetDogsOfSub("hound", "afghans", 40);

//we will check if this has an error. It Does.
//this checks if the BadRequest.Code is not equal to 200(OK)
if (randomDogs.HasError)
{
    //output 'error'
    Console.WriteLine(randomDogs.Status);
}
else
{
    //code
}

```

________________________________________________________________________________________

## Nuget Page

#### View the nuget page for this project [here](https://www.nuget.org/packages/RandomDog/)
