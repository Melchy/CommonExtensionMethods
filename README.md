# Common extension methods

This project contains many simple common extension methods. These methods can be used to make code more readable.

## Examples

```csharp

//Convert variable to list with one element
//without extension method
var list = new List(){1};
//with extension method
var list = 1.InList();

//without extension method
int.Parse("1");
//with extension method
"1".ToInt();


var enumberable = new List().AsEnumerable();
//without extension method
foreach(var x in enumerable){
    //...
}
//with extension method
enumerable.ForEach(x=> ...);


var dictionary = new Dictionary<string, string>();
//without extension method
var exists = source.TryGetValue("test", out var value);
var getOrDefault = exists ? value : default(TValue);
//with extension method
var result = dictionary.GetOrDefault("test");

//without extension method
JsonConvert.DeserializeObject("{}");
JsonConvert.SerializeObject(new object());
//with extension method
"{}".FromJson()
new object().ToJson();


//without extension method
DateTimeOffset.UtcNow.AddDays(1);
DateTimeOffset.UtcNow.AddDays(-1);
//with extension method
DateTimeOffset.UtcNow.Tomorrow();
DateTimeOffset.UtcNow.Yesterday();

//without extension method
TimeSpan.FromHours(5);
//with extension method
5.Hours()

//without extension method
DateTimeOffset.UtcNow.AddHours(-5)
//with extension method
5.Hours().Ago()

//and many more
```

## How to use

Copy all extension methods into your solution. Copying allows you to add new extension methods and edit the existing.