E-Ticaret Envanter ve Stok Takip Sistemi
Bu proje, e-ticaret platformları için envanter ve stok yönetimini kolaylaştıran bir uygulamadır. Uygulama, ürünlerin eklenmesi, güncellenmesi, listelenmesi ve silinmesi işlemlerini destekler. Ayrıca, ürünlerin mevcut stok durumlarını izleyebilir ve stok seviyeleri ile ilgili uyarılar alabilirsiniz.

Temel Özellikler

Ürün Yönetimi: Ürün ekleme, güncelleme, silme ve listeleme işlemleri.
Stok İzleme: Ürünlerin stok seviyelerini izleme ve güncelleme.
Swagger Desteği: API belgeleri ve testleri için Swagger entegrasyonu.
Veritabanı Entegrasyonu: PostgreSQL ile veritabanı bağlantısı.
Önbellekleme: Redis kullanarak performans optimizasyonu.

Teknolojiler
ASP.NET Core: Web API ve MVC yapıları için.
PostgreSQL: Veritabanı yönetimi için.
Swagger: API belgeleri ve testleri için.


Kurulum ve Çalıştırma
Projeyi klonlayın:
git clone https://github.com/kullanici_adi/proje_adi.git

Gerekli bağımlılıkları yükleyin:
dotnet restore

Veritabanını güncelleyin:
dotnet ef database update

Uygulamayı başlatın:
dotnet run

Swagger UI'ye erişmek için tarayıcınızda http://localhost:5000/swagger adresine gidin.
