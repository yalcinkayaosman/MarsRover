# MarsRover
MarsRover React&amp;.Net Core Project

Projeyi api ve web kısmı olmak üzere iki bölümde yaptım. 
Web tarafında react.js kullanıldı. Api tarafında ise .net core kullanıldı. 
Apide kullanımı kolaylaştırmak için swagger kütüphanesi eklendi. Bu sayede http://testapi.dustu.net/swagger/index.html adresinden api dökümantasyonuna erişilebilir. 

Ayrıca katmanların görtülebilmesi için mongodb repository kullandım. Burada db bağlantısı olmasa bile katman yapısını güzel göstermek adına implementasyonu yaptım. Controller a gelen bir metot servis ve repository katmanına giderek db ye ulaşıyor. Burada generic bir repo da var, buraya standart repo metotları tanımlanıyor. 

Apide yine aynı şekilde bulunması için bir basic auth implementasyonu da yaptım. Şu an kapalı olan bu yapı açıldığı zaman basic authentication ile apiye erişiliyor.

Apiyi elimde bulunan bir hostinge atıp kullanım sağlamaya çalıştım. http://testapi.dustu.net/api/command adresinden erişilebilir. Body örneği için proje içerisine postmanden export alıp örnek bir request ekledim, dosyalar içerisinde bulabilirsiniz.

