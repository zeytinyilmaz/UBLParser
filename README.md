# Parser

Merhaba,

Entegratör firmalar kimi zaman müşterilerine sistemlerinden gönderilen fatura ve irsaliyelerin UBL dosyaları yerine fatura ve irsaliyeye ait ve içeriğinde imzalı ublini barındıran topluca zarf dosyalarını vermektedir.

Bu durumda da imzalı UBL dosyasını farklı bir entegratörde saklanmak istediğinde dosyanın entegratörlerin sistemlerine göre uyumsuz olması durumları yaşanmaktadır.

Bu durumu çözmek için metin ve dosya işleme yöntemleri ile ister ziplenmiş ister ziplenmeden tutulan zarf xml dosyalarından belgelere ait UBL dosyası metin işleme yöntemleri ile okunup sadece ilgili eBelgenin olduğu faturaya/irsaliyeye ait xml dosyası oluşturmak amaçlanmıştır.

Uygulama imza değerlerinin ve hem UBL TR standartlarına göre hemde önceki entegratörden gönderilmiş hali ile zarf içeriğindeki belge ublini metin işleme yöntemleri ile doğrudan zarf içindei ubl verisini alarak zarfın dosya adı ile birebir aynı dosya adında fatura/irsaliye xml i çıkarmaktadır.

Uygulama yüklenirken yüklendiği kullanıcı bilgisayarındaki aktif kullanıcı hesabı için kendi içindeki ayarların olup olmadığını kontrol etmektedir. 
Eğer program için bir yapılandırma yapılmamışsa yukarıda belirtilen kontrole istinaden ayar ekranı kullanıcıyı karşılamaktadır.

![image](https://github.com/zeytinyilmaz/UBLParser/assets/11462101/34b46723-c809-49ce-b943-0296e3f849b8)

Yukarıdaki ayar ekranından tarama yapmak için hedef olarak gösterilecek klasör yolu, tarama sonucunda ayıklama işlemnin sonucu oluşan fatura/irsaliye ubl dosyasının kaydedileceği dizin için "Dosyaların kayıt edileceği dizin" beklenmektedir. 
Aynı zamanda yapılan ayıklama işlemi sırasında dosyalar dizin altına kayıt edilirken dizin altında en fazla kaç dosya bulundurulacağını belirlemek için "Dizin/Ziplenecek dosya sayısı" alanı ile dizin başına dosya sayısı belirlenebilmektedir.

Ayarları kaydettikten sonra ana ekran olan tarama ve işlem ekranı gelmektedir.
