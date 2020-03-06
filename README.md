# MarsRover
MarsRover React&amp;.Net Core Project

Projeyi api ve web kısmı olmak üzere iki bölümde yaptım. 
Web tarafında react.js kullanıldı.
Api tarafında ise .net core kullanıldı. Apide kullanımı kolaylaştırmak için swagger kütüphanesi eklendi. 
Ayrıca katmanların görtülebilmesi için mongodb repository kullandım. Burada db bağlantısı olmasa bile katman yapısını güzel göstermek adına implementasyonu yaptım.
Apide yine aynı şekilde bulunması için bir basic auth implementasyonu da yaptım. 


Apiyi elimde bulunan bir hostinge atıp kullanım sağlamaya çalıştım. http://testapi.dustu.net/api/command adresinden erişilebilir. Body örneği :

{
"Commands":"MMRMMRMRRM",
"StartCoordinateX":"3",
"StartCoordinateY":"3",
"StartDirection":"e",
"DimensionX":"5",
"DimensionY":"5"
}

