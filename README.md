# Parser

Merhaba,

Entegratör firmalar kimi zaman müşterilerine sistemlerinden gönderilen fatura ve irsaliyelerin UBL dosyaları yerine fatura ve irsaliyeye ait ve içeriğinde imzalı ublini barındıran topluca zarf dosyalarını vermektedir.

Bu durumda da imzalı UBL dosyasını farklı bir entegratörde saklanmak istediğinde dosyanın entegratörlerin sistemlerine göre uyumsuz olması durumları yaşanmaktadır.

Bu durumu çözmek için metin ve dosya işleme yöntemleri ile ister ziplenmiş ister ziplenmeden tutulan zarf xml dosyalarından belgelere ait UBL dosyası metin işleme yöntemleri ile okunup sadece ilgili eBelgenin olduğu faturaya/irsaliyeye ait xml dosyası oluşturmak amaçlanmıştır.

Uygulama imza değerlerinin ve hem UBL TR standartlarına göre hemde önceki entegratörden gönderilmiş hali ile zarf içeriğindeki belge ublini metin işleme yöntemleri ile doğrudan zarf içindei ubl verisini alarak zarfın dosya adı ile birebir aynı dosya adında fatura/irsaliye xml i çıkarmaktadır.

Uygulama yüklenirken yüklendiği kullanıcı bilgisayarındaki aktif kullanıcı hesabı için kendi içindeki ayarların olup olmadığını kontrol etmektedir. 
Eğer program için bir yapılandırma yapılmamışsa yukarıda belirtilen kontrole istinaden ayar ekranı kullanıcıyı karşılamaktadır.

![image](https://github.com/zeytinyilmaz/UBLParser/assets/11462101/df8407d4-467e-42b5-9cdc-23b6fe4ede93)

Yukarıdaki ayar ekranından tarama yapmak için hedef olarak gösterilecek klasör yolu, tarama sonucunda ayıklama işlemnin sonucu oluşan fatura/irsaliye ubl dosyasının kaydedileceği dizin için "Dosyaların kayıt edileceği dizin" beklenmektedir. 
Aynı zamanda yapılan ayıklama işlemi sırasında dosyalar dizin altına kayıt edilirken dizin altında en fazla kaç dosya bulundurulacağını belirlemek için "Dizin/Ziplenecek dosya sayısı" alanı ile dizin başına dosya sayısı belirlenebilmektedir.

Uygulamada iki farklı biçimde ayıklama işlemi bulunmaktadır.
Bu aşamalar "Aşamalı Ayıklama ve Sıkıştırma" seçeneğinin tiklenmesine göre değişmektedir. Tiklenmiş ise kullanıcıya tarama, ayıklama ve sıkıştırma işlemi olan zipleme işlemini ayroı ayrı yaptırmaktadır. Eğer bu işlemlerden biri tamamlanmadan diğerine geçilmeye çalışılırsa kullanıcıyu uyararak sıralamaya uygun işlem yapması için zorlamaktadır.
İlgili seçeneğin tikinin kaldırılması durumunda bütün aşamalar uygulama tarafından tek bir buton ile otomatik olarak uygulanmaktadır.

Ayarları kaydettikten sonra ana ekran olan tarama ve işlem ekranı gelmektedir.
![image](https://github.com/zeytinyilmaz/UBLParser/assets/11462101/26e0359f-f867-4bd8-a39d-5053c95fa90e)

Bu ekrandan öncelikle Tara butonu ile tarama yapılmalıdır.

![image](https://github.com/zeytinyilmaz/UBLParser/assets/11462101/3c358d0b-3bdc-4f7a-9908-082e17948603)

Tarama ardından Ayıklama yaparak işlem bırakılabilir. Yada Sıkıştır butonu ile ziplenebilir.

![image](https://github.com/zeytinyilmaz/UBLParser/assets/11462101/99e77f2e-9701-4397-ab95-d8497568cad7)

Ayıklama işlemi sonucu aşağıdaki gibi ayrı dizinler altında topluca tutulmaktadır.

![image](https://github.com/zeytinyilmaz/UBLParser/assets/11462101/7a81e4e1-bc7f-485a-984b-5bb64d3c1bbe)

Dosya sayısı çok fazla ise paket sayısı alanında belirtilen miktar kadar dosyayı dizin altına attıktan sonra yeni bir dizin oluşturup devam etmektedir.

Ayıklamanın ardından sıkıştırarak zip dosyası haline getirilmek isteniyorsa Sıkıştır butonunun kullanılması gerekmektedir.
![image](https://github.com/zeytinyilmaz/UBLParser/assets/11462101/da29b620-28cb-49ce-b33c-47ee8ea07280)

Ardından sonucunu ekrana basıp bilgi verecektir.

İlgili adımların sonucunda aşağıdaki gibi zip dosyaları oluşturulmuş olacaktır.

![image](https://github.com/zeytinyilmaz/UBLParser/assets/11462101/5428b3d6-3959-4433-8107-52ecb336cb53)


Fakat yukarıda belirtildiği gibi "Aşamalı Ayıklama ve Sıkıştırma" seçeneği işaretlenmedi ise  ana ekran aşağıdaki gibi oluşacaktır.

![image](https://github.com/zeytinyilmaz/UBLParser/assets/11462101/2f9aa8e5-1706-4e22-acbe-da080ed43516)

Burada da Tara ve Ayıkla Butonu ile işlem yapılması yeterlidir. Bütün aşamalı işlemler uygulama tarafından otomatik olarak uygulanacaktır.

![image](https://github.com/zeytinyilmaz/UBLParser/assets/11462101/1431e7b2-5c1c-4af6-83af-a33c711584d5)

Uygulamanın kullanımı ve genel amacı yukarıda belirtildiği gibidir. 

Şimdilik tamamen zarf üzerinden xml çıkarma üzerinedir. İlerleyen süereçlerde ek özellikler ve genel amaçlı kullanım için geliştirme yapılabilir.

.NET 4.5 ile geliştirilmiştir. Bu nedenle işletim sisteminde .NET Fremawork 4.5 versiyonunun kurulu olması gerekmektedir.






