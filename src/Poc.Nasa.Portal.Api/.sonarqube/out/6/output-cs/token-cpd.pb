ñ¨
>C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Api\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. "
AddHttpContextAccessor '
(' (
)( )
;) *
IConfiguration 
_configuration 
= 
null  $
;$ %
string 
_path 
= 
null 
; 
builder!! 
.!! 
Host!! 
.!! %
ConfigureAppConfiguration!! &
(!!& '
(!!' (
hostingContext!!( 6
,!!6 7 
configurationBuilder!!8 L
)!!L M
=>!!N P
{"" 
var## 
env## 
=## 
hostingContext## 
.## 
HostingEnvironment## /
;##/ 0 
configurationBuilder%% 
.%% 
SetBasePath%% $
(%%$ %
env%%% (
.%%( )
ContentRootPath%%) 8
)%%8 9
;%%9 :
_path&& 	
=&&
 
env&& 
.&& 
ContentRootPath&& 
;&&   
configurationBuilder(( 
.)) 	#
AddEnvironmentVariables))	  
())  !
)))! "
.** 	
AddCommandLine**	 
(** 
Environment** #
.**# $
GetCommandLineArgs**$ 6
(**6 7
)**7 8
)**8 9
;**9 :
_configuration,, 
=,,  
configurationBuilder,, )
.,,) *
Build,,* /
(,,/ 0
),,0 1
;,,1 2
}-- 
)-- 
;-- 

AddSerilog// 

(//
 
builder// 
,// 
_path// 
,// 
_configuration// )
)//) *
;//* +
AddMySQL00 
(00 	
builder00	 
,00 
_configuration00  
)00  !
;00! "
AddHealthCheck11 
(11 
builder11 
,11 
_configuration11 &
)11& '
;11' (
builder44 
.44 
Services44 
.44 
AddControllers44 
(44  
config44  &
=>44' )
{55 
config66 

.66
 
Filters66 
.66 
Add66 
(66 
typeof66 
(66 
ExceptionFilter66 -
)66- .
)66. /
;66/ 0
}77 
)77 
.77 
AddJsonOptions77 
(77 
opts77 
=>77 
opts77 
.77 !
JsonSerializerOptions77 4
.774 5

Converters775 ?
.77? @
Add77@ C
(77C D
new77D G#
JsonStringEnumConverter77H _
(77_ `
JsonNamingPolicy77` p
.77p q
	CamelCase77q z
)77z {
)77{ |
)77| }
;77} ~
builder88 
.88 
Services88 
.88 #
AddEndpointsApiExplorer88 (
(88( )
)88) *
;88* +
builder99 
.99 
Services99 
.99 
AddSwaggerGen99 
(99 
)99  
;99  !
builder:: 
.:: 
Services:: 
.::  
AddServiceCollection:: %
(::% &
builder::& -
.::- .
Configuration::. ;
)::; <
;::< =
	AddCommon== 	
(==	 

builder==
 
.== 
Services== 
)== 
;== 
	AddClient>> 	
(>>	 

builder>>
 
.>> 
Services>> 
,>> 
_configuration>> *
)>>* +
;>>+ ,
AddRabbitMQ?? 
(?? 
builder?? 
.?? 
Services?? 
,?? 
_configuration?? ,
)??, -
;??- .
AddRedis@@ 
(@@ 	
builder@@	 
,@@ 
_configuration@@  
)@@  !
;@@! "
stringCC 
corsNameCC 
=CC 
$strCC 
;CC 
builderDD 
.DD 
ServicesDD 
.DD 
AddCorsDD 
(DD 
pDD 
=>DD 
pDD 
.DD  
	AddPolicyDD  )
(DD) *
corsNameDD* 2
,DD2 3
builderDD4 ;
=>DD< >
{EE 
builderFF 
.FF 
WithOriginsFF 
(FF 
$strFF 
)FF 
.GG 	
AllowAnyMethodGG	 
(GG 
)GG 
.HH 	
AllowAnyHeaderHH	 
(HH 
)HH 
;HH 
}II 
)II 
)II 
;II 
varKK 
appKK 
=KK 	
builderKK
 
.KK 
BuildKK 
(KK 
)KK 
;KK 
ifLL 
(LL 
appLL 
.LL 
EnvironmentLL 
.LL 
IsDevelopmentLL !
(LL! "
)LL" #
)LL# $
{MM 
appNN 
.NN 

UseSwaggerNN 
(NN 
)NN 
;NN 
appOO 
.OO 
UseSwaggerUIOO 
(OO 
)OO 
;OO 
}PP 
appQQ 
.QQ $
UseSerilogRequestLoggingQQ 
(QQ 
)QQ 
;QQ 
appRR 
.RR 
UseHttpsRedirectionRR 
(RR 
)RR 
;RR 
appSS 
.SS 
UseAuthorizationSS 
(SS 
)SS 
;SS 
appTT 
.TT 
MapControllersTT 
(TT 
)TT 
;TT 
appUU 
.UU 
UseCorsUU 
(UU 
corsNameUU 
)UU 
;UU 
appVV 
.VV 
UseHealthChecksVV 
(VV 
$strVV *
,VV* +
newVV, /
HealthCheckOptionsVV0 B
(VVB C
)VVC D
{WW 
	PredicateXX 
=XX 
_XX 
=>XX 
trueXX 
,XX 
ResponseWriterYY 
=YY 
WriteResponseYY "
}ZZ 
)ZZ 
;ZZ 
app[[ 
.[[ 
UseHealthChecks[[ 
([[ 
$str[[ +
,[[+ ,
new[[- 0
HealthCheckOptions[[1 C
([[C D
)[[D E
{\\ 
ResponseWriter]] 
=]] 
(]] 
httpContext]] !
,]]! "
result]]# )
)]]) *
=>]]+ -
{^^ 
httpContext__ 
.__ 
Response__ 
.__ 
ContentType__ (
=__) *
$str__+ =
;__= >
varaa 
jsonaa 
=aa 
newaa 
JObjectaa 
(aa 
newbb 
	JPropertybb 
(bb 
$strbb "
,bb" #
resultbb$ *
.bb* +
Statusbb+ 1
.bb1 2
ToStringbb2 :
(bb: ;
)bb; <
)bb< =
,bb= >
newcc 
	JPropertycc 
(cc 
$strcc #
,cc# $
newcc% (
JObjectcc) 0
(cc0 1
resultcc1 7
.cc7 8
Entriescc8 ?
.cc? @
Selectcc@ F
(ccF G
pairccG K
=>ccL N
newdd 
	JPropertydd 
(dd 
pairdd "
.dd" #
Keydd# &
,dd& '
newdd( +
JObjectdd, 3
(dd3 4
newee 
	JPropertyee !
(ee! "
$stree" *
,ee* +
pairee, 0
.ee0 1
Valueee1 6
.ee6 7
Statusee7 =
.ee= >
ToStringee> F
(eeF G
)eeG H
)eeH I
,eeI J
newff 
	JPropertyff !
(ff! "
$strff" /
,ff/ 0
pairff1 5
.ff5 6
Valueff6 ;
.ff; <
Descriptionff< G
)ffG H
,ffH I
newgg 
	JPropertygg !
(gg! "
$strgg" (
,gg( )
newgg* -
JObjectgg. 5
(gg5 6
pairgg6 :
.gg: ;
Valuegg; @
.gg@ A
DataggA E
.ggE F
SelectggF L
(ggL M
phh 
=>hh 
newhh  
	JPropertyhh! *
(hh* +
phh+ ,
.hh, -
Keyhh- 0
,hh0 1
phh2 3
.hh3 4
Valuehh4 9
)hh9 :
)hh: ;
)hh; <
)hh< =
)hh= >
)hh> ?
)hh? @
)hh@ A
)hhA B
)hhB C
;hhC D
returnjj 
httpContextjj 
.jj 
Responsejj #
.jj# $

WriteAsyncjj$ .
(jj. /
jsonjj/ 3
.jj3 4
ToStringjj4 <
(jj< =

Formattingjj= G
.jjG H
IndentedjjH P
)jjP Q
)jjQ R
;jjR S
}kk 
}ll 
)ll 
;ll 
appmm 
.mm 
Runmm 
(mm 
)mm 	
;mm	 

staticoo 
voidoo 
	AddCommonoo 
(oo 
IServiceCollectionoo (
servicesoo) 1
)oo1 2
{pp 
servicesqq 
.qq 
AddControllersqq 
(qq 
)qq 
.qq 
AddFluentValidationqq 1
(qq1 2
fvqq2 4
=>qq5 7
fvqq8 :
.qq: ;4
(RegisterValidatorsFromAssemblyContainingqq; c
<qqc d'
GetPictureOfTheDayValidatorqqd 
>	qq Ä
(
qqÄ Å
)
qqÅ Ç
)
qqÇ É
;
qqÉ Ñ
servicesrr 
.rr 

AddMediatRrr 
(rr 
cfgrr 
=>rr 
cfgrr "
.rr" #(
RegisterServicesFromAssemblyrr# ?
(rr? @
typeofrr@ F
(rrF G
ProgramrrG N
)rrN O
.rrO P
AssemblyrrP X
)rrX Y
)rrY Z
;rrZ [
servicesss 
.ss 
AddAutoMapperss 
(ss 
typeofss !
(ss! " 
ConfigurationMappingss" 6
)ss6 7
)ss7 8
;ss8 9
servicesuu 
.uu 
	AddScopeduu 
<uu 
IUnitOfWorkuu "
,uu" #

UnitOfWorkuu$ .
>uu. /
(uu/ 0
)uu0 1
;uu1 2
servicesvv 
.vv 
	AddScopedvv 
<vv 
ICacheServicevv $
,vv$ %
CacheServicevv& 2
>vv2 3
(vv3 4
)vv4 5
;vv5 6
servicesxx 
.xx 
	AddScopedxx 
<xx 
IRequestHandlerxx &
<xx& '/
#GetPictureOfTheDayRequestHandlerDtoxx' J
,xxJ K0
$GetPictureOfTheDayResponseHandlerDtoxxL p
>xxp q
,xxq r&
GetPictureOfTheDayHandler	xxs å
>
xxå ç
(
xxç é
)
xxé è
;
xxè ê
servicesyy 
.yy 
	AddScopedyy 
<yy 
IRequestHandleryy &
<yy& '2
&GetAllPictureOfTheDayRequestHandlerDtoyy' M
,yyM N3
'GetAllPictureOfTheDayResponseHandlerDtoyyO v
>yyv w
,yyw x)
GetAllPictureOfTheDayHandler	yyy ï
>
yyï ñ
(
yyñ ó
)
yyó ò
;
yyò ô
serviceszz 
.zz 
	AddScopedzz 
<zz 
IRequestHandlerzz &
<zz& '&
DashboardRequestHandlerDtozz' A
,zzA B'
DashboardResponseHandlerDtozzC ^
>zz^ _
,zz_ `
DashboardHandlerzza q
>zzq r
(zzr s
)zzs t
;zzt u
}{{ 
static}} 
void}} 
	AddClient}} 
(}} 
IServiceCollection}} (
services}}) 1
,}}1 2
IConfiguration}}3 A
config}}B H
)}}H I
{~~ 
var 
timeout 
= 
new 
TimeSpan 
( 
$num  
,  !
$num" #
,# $
$num% '
)' (
;( )
var
ÄÄ 
	mediaType
ÄÄ 
=
ÄÄ 
new
ÄÄ -
MediaTypeWithQualityHeaderValue
ÄÄ 7
(
ÄÄ7 8
$str
ÄÄ8 J
)
ÄÄJ K
;
ÄÄK L
var
ÅÅ 
nasaBaseAddress
ÅÅ 
=
ÅÅ 
new
ÅÅ 
Uri
ÅÅ !
(
ÅÅ! "
$"
ÅÅ" $
{
ÅÅ$ %
config
ÅÅ% +
.
ÅÅ+ ,
ApiNasaAddress
ÅÅ, :
(
ÅÅ: ;
)
ÅÅ; <
}
ÅÅ< =
"
ÅÅ= >
)
ÅÅ> ?
;
ÅÅ? @
services
ÑÑ 
.
ÑÑ 
AddHttpClient
ÑÑ 
(
ÑÑ 
NamedHttpClients
ÑÑ +
.
ÑÑ+ , 
NASA_PORTAL_CLIENT
ÑÑ, >
)
ÑÑ> ?
.
ÑÑ? @!
ConfigureHttpClient
ÑÑ@ S
(
ÑÑS T
x
ÑÑT U
=>
ÑÑV X
{
ÖÖ 
x
ÜÜ 	
.
ÜÜ	 

BaseAddress
ÜÜ
 
=
ÜÜ 
nasaBaseAddress
ÜÜ '
;
ÜÜ' (
x
áá 	
.
áá	 
#
DefaultRequestHeaders
áá
 
.
áá  
Accept
áá  &
.
áá& '
Clear
áá' ,
(
áá, -
)
áá- .
;
áá. /
x
àà 	
.
àà	 
#
DefaultRequestHeaders
àà
 
.
àà  
Accept
àà  &
.
àà& '
Add
àà' *
(
àà* +
	mediaType
àà+ 4
)
àà4 5
;
àà5 6
x
ââ 	
.
ââ	 

Timeout
ââ
 
=
ââ 
timeout
ââ 
;
ââ 
}
ää 
)
ää 
;
ää 
services
åå 
.
åå 
	AddScoped
åå 
<
åå 
INasaPortalClient
åå (
>
åå( )
(
åå) *
p
åå* +
=>
åå, .
new
çç 
NasaPortalClient
çç 
(
çç 
new
éé 
BaseHttpClient
éé 
(
éé 
p
èè 
.
èè 

GetService
èè 
<
èè  
IHttpClientFactory
èè /
>
èè/ 0
(
èè0 1
)
èè1 2
.
èè2 3
CreateClient
èè3 ?
(
èè? @
NamedHttpClients
èè@ P
.
èèP Q 
NASA_PORTAL_CLIENT
èèQ c
)
èèc d
,
èèd e
p
êê 
.
êê 

GetService
êê 
<
êê 
ILogger
êê $
<
êê$ %
BaseHttpClient
êê% 3
>
êê3 4
>
êê4 5
(
êê5 6
)
êê6 7
)
ëë 
,
ëë 
p
íí 
.
íí 

GetService
íí 
<
íí 
ILogger
íí  
<
íí  !
NasaPortalClient
íí! 1
>
íí1 2
>
íí2 3
(
íí3 4
)
íí4 5
,
íí5 6
config
ìì 
.
ìì 
ApiNasaApiKey
ìì  
(
ìì  !
)
ìì! "
)
ìì" #
)
îî 	
;
îî	 

}ïï 
staticóó 
void
óó 
AddRabbitMQ
óó 
(
óó  
IServiceCollection
óó *
services
óó+ 3
,
óó3 4
IConfiguration
óó5 C
config
óóD J
)
óóJ K
=>
óóL N
services
òò 
.
òò 
	AddScoped
òò 
<
òò !
ISetupMessageBroker
òò *
>
òò* +
(
òò+ ,
p
òò, -
=>
òò. 0
new
ôô  
SetupMessageBroker
ôô 
(
ôô 
config
öö 
.
öö 
RabbitHostname
öö !
(
öö! "
)
öö" #
,
öö# $
config
õõ 
.
õõ 
RabbitVHost
õõ 
(
õõ 
)
õõ  
,
õõ  !
config
úú 
.
úú 
RabbitUsername
úú !
(
úú! "
)
úú" #
,
úú# $
config
ùù 
.
ùù 
RabbitPassord
ùù  
(
ùù  !
)
ùù! "
)
ùù" #
)
ûû 
;
ûû 
static†† 
void
†† 

AddSerilog
†† 
(
†† #
WebApplicationBuilder
†† ,
builder
††- 4
,
††4 5
string
††6 <
path
††= A
,
††A B
IConfiguration
††C Q
config
††R X
)
††X Y
=>
††Z \
builder
°° 
.
°° 
Host
°° 
.
°° 

UseSerilog
°° 
(
°° 
(
°° 
context
°° $
,
°°$ %
configuration
°°& 3
)
°°3 4
=>
°°5 7
configuration
¢¢ 
.
¢¢ 
ReadFrom
¢¢ 
.
¢¢ 
Configuration
¢¢ (
(
¢¢( )
context
¢¢) 0
.
¢¢0 1
Configuration
¢¢1 >
)
¢¢> ?
)
≠≠ 
;
≠≠ 
staticØØ 
void
ØØ 
AddMySQL
ØØ 
(
ØØ #
WebApplicationBuilder
ØØ *
builder
ØØ+ 2
,
ØØ2 3
IConfiguration
ØØ4 B
config
ØØC I
)
ØØI J
{∞∞ 
string
±± 


connection
±± 
=
±± 
config
±± 
.
±± 
ConnectionString
±± /
(
±±/ 0
)
±±0 1
;
±±1 2
var
≤≤ 
serverVersion
≤≤ 
=
≤≤ 
new
≤≤  
MySqlServerVersion
≤≤ .
(
≤≤. /
new
≤≤/ 2
Version
≤≤3 :
(
≤≤: ;
$num
≤≤; <
,
≤≤< =
$num
≤≤> ?
,
≤≤? @
$num
≤≤A C
)
≤≤C D
)
≤≤D E
;
≤≤E F
builder
≥≥ 
.
≥≥ 
Services
≥≥ 
.
≥≥ 
AddDbContext
≥≥ !
<
≥≥! "
NasaPortalContext
≥≥" 3
>
≥≥3 4
(
≥≥4 5
o
≥≥5 6
=>
≥≥7 9
o
≥≥: ;
.
≥≥; <
UseMySql
≥≥< D
(
≥≥D E

connection
≥≥E O
,
≥≥O P
serverVersion
≥≥Q ^
)
≥≥^ _
)
≥≥_ `
;
≥≥` a
}¥¥ 
static∂∂ 
void
∂∂ 
AddHealthCheck
∂∂ 
(
∂∂ #
WebApplicationBuilder
∂∂ 0
builder
∂∂1 8
,
∂∂8 9
IConfiguration
∂∂: H
config
∂∂I O
)
∂∂O P
{∑∑ 
string
∏∏ 

rabbitConnection
∏∏ 
=
∏∏ 
$"
∏∏  
$str
∏∏  (
{
∏∏( )
builder
∏∏) 0
.
∏∏0 1
Configuration
∏∏1 >
[
∏∏> ?
$str
∏∏? R
]
∏∏R S
}
∏∏S T
$str
∏∏T U
{
∏∏U V
builder
∏∏V ]
.
∏∏] ^
Configuration
∏∏^ k
[
∏∏k l
$str
∏∏l 
]∏∏ Ä
}∏∏Ä Å
$str∏∏Å Ç
{∏∏Ç É
builder∏∏É ä
.∏∏ä ã
Configuration∏∏ã ò
[∏∏ò ô
$str∏∏ô ™
]∏∏™ ´
}∏∏´ ¨
$str∏∏¨ ≠
{∏∏≠ Æ
builder∏∏Æ µ
.∏∏µ ∂
Configuration∏∏∂ √
[∏∏√ ƒ
$str∏∏ƒ ‘
]∏∏‘ ’
}∏∏’ ÷
"∏∏÷ ◊
;∏∏◊ ÿ
builder
∫∫ 
.
∫∫ 
Services
∫∫ 
.
∫∫ 
AddHealthChecks
∫∫ $
(
∫∫$ %
)
∫∫% &
.
ªª !
AddHealthCheckMySql
ªª 
(
ªª 
config
ªª 
.
ªª  
ConnectionString
ªª  0
(
ªª0 1
)
ªª1 2
,
ªª2 3
name
ªª4 8
:
ªª8 9
$str
ªª: A
)
ªªA B
.
ºº $
AddHealthCheckRabbitMQ
ºº 
(
ºº 
rabbitConnection
ºº ,
,
ºº, -
config
ºº. 4
,
ºº4 5
name
ºº6 :
:
ºº: ;
$str
ºº< F
)
ººF G
.
ΩΩ 
AddRedis
ΩΩ 
(
ΩΩ 
config
ΩΩ 
.
ΩΩ 
RedisServer
ΩΩ  
(
ΩΩ  !
)
ΩΩ! "
.
ΩΩ" #
Replace
ΩΩ# *
(
ΩΩ* +
$str
ΩΩ+ 5
,
ΩΩ5 6
$str
ΩΩ7 9
)
ΩΩ9 :
,
ΩΩ: ;
$str
ΩΩ< C
,
ΩΩC D
HealthStatus
ΩΩE Q
.
ΩΩQ R
Degraded
ΩΩR Z
)
ΩΩZ [
.
ææ 
AddCheck
ææ 
<
ææ 
GCInfoHealthCheck
ææ 
>
ææ  
(
ææ  !
$str
ææ! %
)
ææ% &
;
ææ& '
}øø 
static¡¡ 
void
¡¡ 
AddRedis
¡¡ 
(
¡¡ #
WebApplicationBuilder
¡¡ *
builder
¡¡+ 2
,
¡¡2 3
IConfiguration
¡¡4 B
config
¡¡C I
)
¡¡I J
{¬¬ 
var
√√ 
provider
√√ 
=
√√ 
new
√√ %
RedisConnectionProvider
√√ .
(
√√. /
config
√√/ 5
.
√√5 6
RedisServer
√√6 A
(
√√A B
)
√√B C
)
√√C D
;
√√D E
builder
ƒƒ 
.
ƒƒ 
Services
ƒƒ 
.
ƒƒ 
AddSingleton
ƒƒ !
(
ƒƒ! "
provider
ƒƒ" *
)
ƒƒ* +
;
ƒƒ+ ,
}≈≈ 
static«« 
Task
«« 
WriteResponse
«« 
(
«« 
HttpContext
«« %
httpContext
««& 1
,
««1 2
HealthReport
««3 ?
result
««@ F
)
««F G
{»» 
httpContext
…… 
.
…… 
Response
…… 
.
…… 
ContentType
…… $
=
……% &
$str
……' 2
;
……2 3
return
   

httpContext
   
.
   
Response
   
.
    

WriteAsync
    *
(
  * +
result
  + 1
.
  1 2
Status
  2 8
.
  8 9
ToString
  9 A
(
  A B
)
  B C
)
  C D
;
  D E
}ÀÀ Ó
NC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Api\Filters\ExceptionFilter.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Api 
. 
Filters %
;% &
internal		 
sealed			 
class		 
ExceptionFilter		 %
:		& '
IExceptionFilter		( 8
{

 
private 
readonly 
ILogger 
< 
ExceptionFilter ,
>, -
_logger. 5
;5 6
private 
readonly  
IHttpContextAccessor ) 
_httpContextAccessor* >
;> ?
public 

ExceptionFilter 
( 
ILogger "
<" #
ExceptionFilter# 2
>2 3
logger4 :
,: ; 
IHttpContextAccessor< P
httpContextAccessorQ d
)d e
{ 
_logger 
= 
logger 
;  
_httpContextAccessor 
= 
httpContextAccessor 2
;2 3
} 
public 

void 
OnException 
( 
ExceptionContext ,
context- 4
)4 5
{ 
var 
correlationId 
=  
_httpContextAccessor 0
?0 1
.1 2
HttpContext2 =
?= >
.> ?
Request? F
.F G
HeadersG N
[N O
$strO Y
]Y Z
.Z [
ToString[ c
(c d
)d e
;e f
if 

( 
correlationId 
is 
null !
)! "
correlationId 
= 
Guid  
.  !
NewGuid! (
(( )
)) *
.* +
ToString+ 3
(3 4
)4 5
;5 6
var 
response 
= 
context 
. 
HttpContext *
.* +
Response+ 3
;3 4
response 
. 

StatusCode 
= 
( 
int "
)" #
HttpStatusCode# 1
.1 2

BadRequest2 <
;< =
response 
. 
ContentType 
= 
$str 1
;1 2
context 
. 
ExceptionHandled  
=! "
true# '
;' (
context   
.   
Result   
=   
new   "
BadRequestObjectResult   3
(  3 4
new!! 
[!! 
]!! 
{"" 
new## 
BadRequestDto## !
{$$ 
Code%% 
=%% 
MessageValidation%% ,
.%%, -
GeneralError%%- 9
.%%9 :
code%%: >
,%%> ?
Message&& 
=&& 
MessageValidation&& /
.&&/ 0
GeneralError&&0 <
.&&< =
description&&= H
}'' 
}(( 
)(( 
;(( 
_logger** 
.** 
LogError** 
(** 
context**  
.**  !
	Exception**! *
,*** +
null**, 0
)**0 1
;**1 2
}++ 
},, ø>
]C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Api\Extensions\ServiceCollectionExtensions.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Api 
. 

Extensions (
;( )
public

 
static

 
class

 '
ServiceCollectionExtensions

 /
{ 
public 

static 
void  
AddServiceCollection +
(+ ,
this, 0
IServiceCollection1 C
servicesD L
,L M
IConfigurationN \
configuration] j
)j k
{ 
services 
. "
AddHttpContextAccessor '
(' (
)( )
;) *
services 
. $
AddApisServiceCollection )
() *
configuration* 7
)7 8
;8 9
} 
public 

static  
IHealthChecksBuilder &"
AddHealthCheckRabbitMQ' =
( 
this  
IHealthChecksBuilder !
builder" )
,) *
string "
rabbitConnectionString %
,% &
IConfiguration 
configuration $
,$ %
	SslOption 
	sslOption 
= 
null "
," #
string 
name 
= 
default 
, 
HealthStatus 
? 
failureStatus #
=$ %
default& -
,- .
IEnumerable 
< 
string 
> 
tags  
=! "
default# *
,* +
TimeSpan, 4
?4 5
timeout6 =
=> ?
default@ G
) 
{ 
builder 
. 
Services 
. 
AddSingleton %
(% &
sp& (
=>) +
new, /
RabbitMQHealthCheck0 C
(C D
newD G
ConnectionFactoryH Y
(Y Z
)Z [
{ 	
UserName 
= 
configuration $
.$ %
RabbitUsername% 3
(3 4
)4 5
,5 6
Password   
=   
configuration   $
.  $ %
RabbitPassord  % 2
(  2 3
)  3 4
,  4 5
VirtualHost!! 
=!! 
configuration!! '
.!!' (
RabbitVHost!!( 3
(!!3 4
)!!4 5
,!!5 6
HostName"" 
="" 
configuration"" $
.""$ %
RabbitHostname""% 3
(""3 4
)""4 5
}## 	
,##	 

configuration## 
)## 
)## 
;## 
var%% 
hc%% 
=%% 
new%% #
HealthCheckRegistration%% ,
(%%, -
name&& 
??&& 
$str&& 
,&& 
sp'' 
=>'' 
sp'' 
.'' 
GetRequiredService'' '
<''' (
RabbitMQHealthCheck''( ;
>''; <
(''< =
)''= >
,''> ?
failureStatus(( 
,(( 
tags)) 
,)) 
timeout** 
)** 
;** 
hc,, 

.,,
 
FailureStatus,, 
=,, 
hc,, 
.,, 
FailureStatus,, +
==,,, .
HealthStatus,,/ ;
.,,; <
Healthy,,< C
?,,D E
HealthStatus-- 
.-- 
Healthy--  
:--! "
HealthStatus--# /
.--/ 0
Degraded--0 8
;--8 9
return// 
builder// 
.// 
Add// 
(// 
hc// 
)// 
;// 
}00 
public22 

static22  
IHealthChecksBuilder22 &
AddHealthCheckMySql22' :
(33 	
this44  
IHealthChecksBuilder44 %
builder44& -
,44- .
string55 
connectionString55 #
,55# $
string66 
healthQuery66 
=66  
default66! (
,66( )
string77 
name77 
=77 
default77 !
,77! "
HealthStatus88 
?88 
failureStatus88 '
=88( )
default88* 1
,881 2
IEnumerable99 
<99 
string99 
>99 
tags99  $
=99% &
default99' .
,99. /
TimeSpan:: 
?:: 
timeout:: 
=:: 
default::  '
,::' (
Action;; 
<;; 
MySqlConnection;; "
>;;" #*
beforeOpenConnectionConfigurer;;$ B
=;;C D
default;;E L
)<< 	
=><<
 
builder== 
.== 
AddHealthCheckMySql== #
(==# $
_==$ %
=>==& (
connectionString==) 9
,==9 :
healthQuery==; F
,==F G
name==H L
,==L M
failureStatus==N [
,==[ \
tags==] a
,==a b
timeout==c j
,==j k+
beforeOpenConnectionConfigurer	==l ä
)
==ä ã
;
==ã å
private?? 
static??  
IHealthChecksBuilder?? '
AddHealthCheckMySql??( ;
(@@ 
thisAA 
 
IHealthChecksBuilderAA 
builderAA  '
,AA' (
FuncBB 

<BB
 
IServiceProviderBB 
,BB 
stringBB #
>BB# $#
connectionStringFactoryBB% <
,BB< =
stringCC 
healthQueryCC 
=CC 
defaultCC "
,CC" #
stringDD 
nameDD 
=DD 
defaultDD 
,DD 
HealthStatusEE 
?EE 
failureStatusEE !
=EE" #
defaultEE$ +
,EE+ ,
IEnumerableFF 
<FF 
stringFF 
>FF 
tagsFF 
=FF  
defaultFF! (
,FF( )
TimeSpanGG 
?GG 
timeoutGG 
=GG 
defaultGG !
,GG! "
ActionHH 
<HH 
MySqlConnectionHH 
>HH *
beforeOpenConnectionConfigurerHH <
=HH= >
defaultHH? F
)II 
{JJ 
ifKK 

(KK #
connectionStringFactoryKK #
==KK$ &
nullKK' +
)KK+ ,
throwLL 
newLL !
ArgumentNullExceptionLL +
(LL+ ,
nameofLL, 2
(LL2 3#
connectionStringFactoryLL3 J
)LLJ K
)LLK L
;LLL M
varNN 
hcNN 
=NN 
newNN #
HealthCheckRegistrationNN ,
(NN, -
nameOO 
??OO 
$strOO 
,OO 
spPP 
=>PP 
newPP 
MysqlHealthCheckPP &
(PP& '#
connectionStringFactoryPP' >
(PP> ?
spPP? A
)PPA B
,PPB C
healthQueryPPD O
??PPP R
$strPPS ^
,PP^ _*
beforeOpenConnectionConfigurerPP` ~
)PP~ 
,	PP Ä
failureStatusQQ 
,QQ 
tagsRR 
,RR 
timeoutSS 
)SS 
;SS 
hcUU 

.UU
 
FailureStatusUU 
=UU 
hcUU 
.UU 
FailureStatusUU +
==UU, .
HealthStatusUU/ ;
.UU; <
HealthyUU< C
?UUD E
HealthStatusVV 
.VV 
HealthyVV  
:VV! "
HealthStatusVV# /
.VV/ 0
DegradedVV0 8
;VV8 9
returnXX 
builderXX 
.XX 
AddXX 
(XX 
hcXX 
)XX 
;XX 
}YY 
}ZZ ˚
VC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Api\Controllers\DashboardController.cs
	namespace		 	
Poc		
 
.		 
Nasa		 
.		 
Portal		 
.		 
Api		 
.		 
Controllers		 )
;		) *
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
sealed 
class 
DashboardController '
:( )#
AstronomyBaseController* A
{ 
public 

DashboardController 
( 
	IMediator (
mediator) 1
)1 2
:3 4
base5 9
(9 :
mediator: B
)B C
{ 
} 
[ 
HttpGet 
] 
[ 
Route 

(
 
$str 
) 
] 
[  
ProducesResponseType 
( 
typeof  
(  !'
DashboardResponseHandlerDto! <
)< =
,= >
(? @
int@ C
)C D
HttpStatusCodeD R
.R S
OKS U
)U V
]V W
[  
ProducesResponseType 
( 
typeof  
(  !
BadRequestDto! .
). /
,/ 0
(1 2
int2 5
)5 6
HttpStatusCode6 D
.D E

BadRequestE O
)O P
]P Q
public 

async 
Task 
< 
IActionResult #
># $
GetDashboardAsync% 6
( 
[ 	

FromHeader	 
( 
Name 
= 
TrackId "
)" #
]# $
[$ %
Required% -
]- .
Guid/ 3
trackId4 ;
,; <
CancellationToken 
ct 
) 
{ 
var 
response 
= 
base 
. 
Mediator $
.$ %
Send% )
() *
new &
DashboardRequestHandlerDto *
(* +
trackId+ 2
)2 3
,3 4
ct 
) 
; 
if   

(   
response   
.   
Result   
.   
IsValid   #
(  # $
)  $ %
)  % &
return!! 
Ok!! 
(!! 
response!! 
.!! 
Result!! %
)!!% &
;!!& '
return## 

BadRequest## 
(## 
response## "
.##" #
Result### )
.##) *
	GetErrors##* 3
(##3 4
)##4 5
)##5 6
;##6 7
}$$ 
}%% µ
_C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Api\Controllers\Base\AstronomyBaseController.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Api 
. 
Controllers )
.) *
Base* .
;. /
public 
abstract 
class #
AstronomyBaseController -
:. /
ControllerBase0 >
{ 
	protected 
const 
string 
TrackId "
=# $
$str% /
;/ 0
	protected		 
readonly		 
	IMediator		  
Mediator		! )
;		) *
	protected #
AstronomyBaseController %
(% &
	IMediator& /
mediator0 8
)8 9
=>: <
Mediator 
= 
mediator 
; 
} •*
]C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Api\Controllers\AstronomyPictureController.cs
	namespace

 	
Poc


 
.

 
Nasa

 
.

 
Portal

 
.

 
Api

 
.

 
Controllers

 )
;

) *
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
sealed 
class &
AstronomyPictureController .
:/ 0#
AstronomyBaseController1 H
{ 
public 
&
AstronomyPictureController %
(% &
	IMediator& /
mediator0 8
)8 9
:: ;
base< @
(@ A
mediatorA I
)I J
{ 
} 
[ 
HttpGet 
] 
[ 
Route 

(
 
$str 
) 
] 
[  
ProducesResponseType 
( 
typeof  
(  !0
$GetPictureOfTheDayResponseHandlerDto! E
)E F
,F G
(H I
intI L
)L M
HttpStatusCodeM [
.[ \
OK\ ^
)^ _
]_ `
[  
ProducesResponseType 
( 
typeof  
(  !
BadRequestDto! .
). /
,/ 0
(1 2
int2 5
)5 6
HttpStatusCode6 D
.D E

BadRequestE O
)O P
]P Q
public 

async 
Task 
< 
IActionResult #
># $!
GetPictureByDateAsync% :
( 
[ 	

FromHeader	 
( 
Name 
= 
TrackId "
)" #
]# $
[$ %
Required% -
]- .
Guid/ 3
trackId4 ;
,; <
[ 	
	FromRoute	 
] 
DateTime 
date !
,! "
CancellationToken 
ct 
) 
{ 
var 
response 
= 
base 
. 
Mediator $
.$ %
Send% )
() *
new /
#GetPictureOfTheDayRequestHandlerDto 3
(3 4
new   (
GetPictureOfTheDayRequestDto   0
{  1 2
Date  3 7
=  8 9
date  : >
}  ? @
,  @ A
trackId!! 
)!! 
,!! 
ct"" 
)"" 
;"" 
if$$ 

($$ 
response$$ 
.$$ 
Result$$ 
.$$ 
IsValid$$ #
($$# $
)$$$ %
)$$% &
return%% 
Ok%% 
(%% 
response%% 
.%% 
Result%% %
)%%% &
;%%& '
return'' 

BadRequest'' 
('' 
response'' "
.''" #
Result''# )
.'') *
	GetErrors''* 3
(''3 4
)''4 5
)''5 6
;''6 7
}(( 
[** 
HttpGet** 
]** 
[++ 
Route++ 

(++
 
$str++ 
)++ 
]++ 
[,,  
ProducesResponseType,, 
(,, 
typeof,,  
(,,  !3
'GetAllPictureOfTheDayResponseHandlerDto,,! H
),,H I
,,,I J
(,,K L
int,,L O
),,O P
HttpStatusCode,,P ^
.,,^ _
OK,,_ a
),,a b
],,b c
[--  
ProducesResponseType-- 
(-- 
typeof--  
(--  !
BadRequestDto--! .
)--. /
,--/ 0
(--1 2
int--2 5
)--5 6
HttpStatusCode--6 D
.--D E

BadRequest--E O
)--O P
]--P Q
public.. 

async.. 
Task.. 
<.. 
IActionResult.. #
>..# $
GetAllPicturesAsync..% 8
(// 
[00 	

FromHeader00	 
(00 
Name00 
=00 
TrackId00 "
)00" #
]00# $
[00$ %
Required00% -
]00- .
Guid00/ 3
trackId004 ;
,00; <
CancellationToken11 
ct11 
)22 
{33 
var44 
response44 
=44 
base44 
.44 
Mediator44 $
.44$ %
Send44% )
(44) *
new55 2
&GetAllPictureOfTheDayRequestHandlerDto55 6
(556 7
trackId557 >
)55> ?
,55? @
ct66 
)66 
;66 
if88 

(88 
response88 
.88 
Result88 
.88 
IsValid88 #
(88# $
)88$ %
)88% &
return99 
Ok99 
(99 
response99 
.99 
Result99 %
.99% &
PicturesOfTheDay99& 6
)996 7
;997 8
return;; 

BadRequest;; 
(;; 
response;; "
.;;" #
Result;;# )
.;;) *
	GetErrors;;* 3
(;;3 4
);;4 5
);;5 6
;;;6 7
}<< 
}== 