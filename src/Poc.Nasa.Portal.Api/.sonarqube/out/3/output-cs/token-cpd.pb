¶
^C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\Dashboard\Handle_\DashboardHandler.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Nasa "
." #
	Dashboard# ,
;, -
public

 
sealed

 
class

 
DashboardHandler

 $
:

% &
IRequestHandler

' 6
<

6 7&
DashboardRequestHandlerDto

7 Q
,

Q R'
DashboardResponseHandlerDto

S n
>

n o
{ 
private 
readonly 
ILogger 
< 
DashboardHandler -
>- .
_logger/ 6
;6 7
private 
readonly 
IUnitOfWork  
_unitOfWork! ,
;, -
private 
readonly 
IMapper 
_mapper $
;$ %
public 

DashboardHandler 
( 
ILogger 
< 
DashboardHandler  
>  !
logger" (
,( )
IUnitOfWork 

unitOfWork 
, 
IMapper 
mapper 
) 
{ 
_logger 
= 
logger 
; 
_unitOfWork 
= 

unitOfWork  
;  !
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< '
DashboardResponseHandlerDto 1
>1 2
Handle3 9
(9 :&
DashboardRequestHandlerDto "
request# *
,* +
CancellationToken, =
cancellationToken> O
)O P
{ 
_logger 
. 
LogInformation 
( 
$str 6
)6 7
;7 8
var!! 
response!! 
=!! 
new!! '
DashboardResponseHandlerDto!! 6
(!!6 7
)!!7 8
;!!8 9
if## 

(## 
await## 
_unitOfWork## 
.## %
PictureOfTheDayRepository## 7
.##7 8
GetAllAsync##8 C
(##C D
cancellationToken##D U
)##U V
is$$ 
var$$ 
picture$$ 
&&$$ 
picture$$ %
is$$& (
null$$) -
)$$- .
{%% 	
response&& 
.&& 
SetError&& 
(&& 
new&& !
ErrorResponse&&" /
(&&/ 0
MessageValidation'' !
.''! "
NoDataFound''" -
.''- .
code''. 2
,''2 3
MessageValidation(( !
.((! "
NoDataFound((" -
.((- .
description((. 9
)((9 :
)((: ;
;((; <
return** 
response** 
;** 
}++ 	
response-- 
.-- '
TotalRecordsPictureOfTheDay-- ,
=--- .
picture--/ 6
.--6 7
Count--7 <
;--< =
return.. 
response.. 
;.. 
}// 
}00 í
ÜC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\AstronomyPicture\GetPictureOfTheDay\Validator_\GetPictureOfTheDayValidator.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Nasa "
." #
AstronomyPicture# 3
.3 4
GetPictureOfTheDay4 F
;F G
public 
sealed 
class '
GetPictureOfTheDayValidator /
:0 1
AbstractValidator2 C
<C D(
GetPictureOfTheDayRequestDtoD `
>` a
{ 
public 
'
GetPictureOfTheDayValidator &
(& '
)' (
=>) +
RuleFor		 
(		 
s		 
=>		 
s		 
.		 
Date		 
)		 
.

 
Must

 
(

 #
ValidateDateGreaterThan

 )
)

) *
.

* +
WithErrorCode

+ 8
(

8 9
MessageValidation

9 J
.

J K
DateLessThan

K W
.

W X
code

X \
)

\ ]
.* +
WithMessage+ 6
(6 7
MessageValidation7 H
.H I
DateLessThanI U
.U V
descriptionV a
)a b
;b c
private 
bool #
ValidateDateGreaterThan (
(( )
DateTime) 1
date2 6
)6 7
=>8 :
date 
> 
DateTime 
. 
Parse 
( 
$str *
)* +
;+ ,
} ¬,
VC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\HealthCheck\RabbitMQHealthCheck.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
HealthCheck )
;) *
public 
sealed 
class 
RabbitMQHealthCheck '
:( )
IHealthCheck* 6
{		 
private

 
IConfiguration

 
_configuration

 )
;

) *
private 
IConnection 
_connection #
;# $
private 
IConnectionFactory 
_factory '
;' (
private 
readonly 
Uri #
_rabbitConnectionString 0
;0 1
private 
readonly 
	SslOption 

_sslOption )
;) *
public 

RabbitMQHealthCheck 
( 
IConnection *

connection+ 5
,5 6
IConfiguration7 E
configurationF S
)S T
{ 
_connection 
= 

connection  
??! #
throw$ )
new* -!
ArgumentNullException. C
(C D
nameofD J
(J K

connectionK U
)U V
)V W
;W X
_configuration 
= 
configuration &
??' )
throw* /
new0 3!
ArgumentNullException4 I
(I J
nameofJ P
(P Q
configurationQ ^
)^ _
)_ `
;` a
} 
public 

RabbitMQHealthCheck 
( 
IConnectionFactory 1
factory2 9
,9 :
IConfiguration; I
configurationJ W
)W X
{ 
_factory 
= 
factory 
?? 
throw #
new$ '!
ArgumentNullException( =
(= >
nameof> D
(D E
factoryE L
)L M
)M N
;N O
_configuration 
= 
configuration &
??' )
throw* /
new0 3!
ArgumentNullException4 I
(I J
nameofJ P
(P Q
configurationQ ^
)^ _
)_ `
;` a
} 
public 

RabbitMQHealthCheck 
( 
Uri ""
rabbitConnectionString# 9
,9 :
	SslOption; D
sslE H
,H I
IConfigurationJ X
configurationY f
)f g
{ #
_rabbitConnectionString 
=  !"
rabbitConnectionString" 8
;8 9

_sslOption 
= 
ssl 
; 
_configuration   
=   
configuration   &
;  & '
}!! 
public$$ 

Task$$ 
<$$ 
HealthCheckResult$$ !
>$$! "
CheckHealthAsync$$# 3
($$3 4
HealthCheckContext$$4 F
context$$G N
,$$N O
CancellationToken$$P a
ct$$b d
=$$e f
default$$g n
)$$n o
{%% 
try&& 
{'' 	
EnsureConnection(( 
((( 
)(( 
;(( 
using** 
(** 
_connection** 
.** 
CreateModel** *
(*** +
)**+ ,
)**, -
{++ 
return,, 
Task,, 
.,, 

FromResult,, &
(,,& '
HealthCheckResult,,' 8
.,,8 9
Healthy,,9 @
(,,@ A
$str,,A K
),,K L
),,L M
;,,M N
}-- 
}.. 	
catch// 
(// 
	Exception// 
ex// 
)// 
{00 	
return11 
Task11 
.11 

FromResult11 "
(11" #
new11# &
HealthCheckResult11' 8
(118 9
context119 @
.11@ A
Registration11A M
.11M N
FailureStatus11N [
,11[ \
	exception11] f
:11f g
ex11h j
)11j k
)11k l
;11l m
}22 	
}33 
private55 
void55 
EnsureConnection55 !
(55! "
)55" #
{77 
if88 

(88 
_connection88 
==88 
null88 
)88  
{99 	
if:: 
(:: 
_factory:: 
==:: 
null::  
)::  !
{;; 
_factory<< 
=<< 
new<< 
ConnectionFactory<< 0
(<<0 1
)<<1 2
{== 
UserName>> 
=>> 
_configuration>> -
.>>- .
RabbitUsername>>. <
(>>< =
)>>= >
,>>> ?
Password?? 
=?? 
_configuration?? -
.??- .
RabbitPassord??. ;
(??; <
)??< =
,??= >
VirtualHost@@ 
=@@  !
_configuration@@" 0
.@@0 1
RabbitVHost@@1 <
(@@< =
)@@= >
,@@> ?
HostNameAA 
=AA 
_configurationAA -
.AA- .
RabbitHostnameAA. <
(AA< =
)AA= >
}BB 
;BB 
}CC 
_connectionEE 
=EE 
_factoryEE "
.EE" #
CreateConnectionEE# 3
(EE3 4
)EE4 5
;EE5 6
}FF 	
}GG 
}HH ±
RC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Shared\Dto_\BaseResponseDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Shared $
;$ %
public 
abstract 
class 
BaseResponseDto %
{ 
	protected 
IList 
< 
ErrorResponse !
>! "
Errors# )
{* +
get, /
;/ 0
private1 8
set9 <
;< =
}> ?
public		 

BaseResponseDto		 
(		 
)		 
=>		 
Errors

 
=

 
new

 
List

 
<

 
ErrorResponse

 '
>

' (
(

( )
)

) *
;

* +
public 

void $
AddErrorValidationResult (
(( )
ValidationResult) 9

validation: D
)D E
{ 
foreach 
( 
ValidationFailure "
item# '
in( *

validation+ 5
.5 6
Errors6 <
)< =
Errors 
. 
Add 
( 
new 
ErrorResponse (
(( )
item) -
.- .
PropertyName. :
,: ;
item< @
.@ A
ErrorMessageA M
)M N
)N O
;O P
} 
public 

void 
SetError 
( 
ErrorResponse &
error' ,
), -
=>. 0
Errors 
. 
Add 
( 
error 
) 
; 
public 

void 
	SetErrors 
( 
IList 
<  
ErrorResponse  -
>- .
errors/ 5
)5 6
{ 
foreach 
( 
ErrorResponse 
error $
in% '
errors( .
). /
Errors 
. 
Add 
( 
error 
) 
; 
} 
public 

bool 
IsValid 
( 
) 
=> 
! 	
Errors	 
. 
Any 
( 
) 
; 
public 

IList 
< 
ErrorResponse 
> 
	GetErrors  )
() *
)* +
=>, .
Errors 
; 
}   
public"" 
sealed"" 
class"" 
ErrorResponse"" !
{## 
public$$ 

string$$ 
Code$$ 
{$$ 
get$$ 
;$$ 
private$$ %
set$$& )
;$$) *
}$$+ ,
public%% 

string%% 
Message%% 
{%% 
get%% 
;%%  
private%%! (
set%%) ,
;%%, -
}%%. /
public'' 

ErrorResponse'' 
('' 
string'' 
code''  $
,''$ %
string''& ,
message''- 4
)''4 5
{(( 
Code)) 
=)) 
code)) 
;)) 
Message** 
=** 
message** 
;** 
}++ 
},, Œ
PC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Shared\Dto_\BadRequestDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Shared $
.$ %
Dt% '
;' (
public 
sealed 
class 
BadRequestDto !
{ 
public 

string 
Code 
{ 
get 
; 
set !
;! "
}# $
public 

string 
Message 
{ 
get 
;  
set! $
;$ %
}& '
} ®
mC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\Dashboard\Dto_\Handler\DashboardRequestHandlerDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Nasa "
." #
	Dashboard# ,
;, -
public 
sealed 
class &
DashboardRequestHandlerDto .
:/ 0
IRequest1 9
<9 :'
DashboardResponseHandlerDto: U
>U V
{ 
public 
&
DashboardRequestHandlerDto %
(% &
Guid& *
trackId+ 2
)2 3
=>4 6
TrackId 
= 
trackId 
; 
public

 

Guid

 
TrackId

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
} ¶
pC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\Dashboard\Dto_\Arguments\DashboardResponseHandlerDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Nasa "
." #
	Dashboard# ,
;, -
public 
sealed 
class '
DashboardResponseHandlerDto /
:0 1
BaseResponseDto2 A
{ 
public 

int '
TotalRecordsPictureOfTheDay *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} ‚>
ÇC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\AstronomyPicture\GetPictureOfTheDay\Handler_\GetPictureOfTheDayHandler.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Nasa "
." #
AstronomyPicture# 3
.3 4
GetPictureOfTheDay4 F
;F G
public 
sealed 
class %
GetPictureOfTheDayHandler -
:. /
IRequestHandler0 ?
<? @/
#GetPictureOfTheDayRequestHandlerDto@ c
,c d1
$GetPictureOfTheDayResponseHandlerDto	e â
>
â ä
{ 
private 
readonly '
GetPictureOfTheDayValidator 0

_validator1 ;
;; <
private 
readonly 
INasaPortalClient &
_nasaPortalClient' 8
;8 9
private 
readonly 
ICacheService "
_cacheService# 0
;0 1
private 
readonly 
IMapper 
_mapper $
;$ %
private 
readonly 
ILogger 
< %
GetPictureOfTheDayHandler 6
>6 7
_logger8 ?
;? @
private 
readonly 
IUnitOfWork  
_unitOfWork! ,
;, -
private 
readonly 
ISetupMessageBroker (
_setupMessageBroker) <
;< =
private 
readonly 
IConfiguration #
_configuration$ 2
;2 3
public 
%
GetPictureOfTheDayHandler $
( '
GetPictureOfTheDayValidator #
	validator$ -
,- .
INasaPortalClient 
nasaPortalClient *
,* +
ICacheService 
cacheService "
," #
IMapper   
mapper   
,   
ILogger!! 
<!! %
GetPictureOfTheDayHandler!! )
>!!) *
logger!!+ 1
,!!1 2
IUnitOfWork"" 

unitOfWork"" 
,"" 
ISetupMessageBroker## 
setupMessageBroker## .
,##. /
IConfiguration$$ 
configuration$$ $
)%% 
{&& 

_validator'' 
='' 
	validator'' 
;'' 
_nasaPortalClient(( 
=(( 
nasaPortalClient(( ,
;((, -
_cacheService)) 
=)) 
cacheService)) $
;))$ %
_mapper** 
=** 
mapper** 
;** 
_logger++ 
=++ 
logger++ 
;++ 
_unitOfWork,, 
=,, 

unitOfWork,,  
;,,  !
_setupMessageBroker-- 
=-- 
setupMessageBroker-- 0
;--0 1
_configuration.. 
=.. 
configuration.. &
;..& '
}// 
public11 

async11 
Task11 
<11 0
$GetPictureOfTheDayResponseHandlerDto11 :
>11: ;
Handle11< B
(11B C/
#GetPictureOfTheDayRequestHandlerDto22 +
request22, 3
,223 4
CancellationToken225 F
cancellationToken22G X
)22X Y
{33 
_logger44 
.44 
LogInformation44 
(44 
$str44 E
)44E F
;44F G
var66 
response66 
=66 
new66 0
$GetPictureOfTheDayResponseHandlerDto66 ?
(66? @
)66@ A
;66A B
if88 

(88 
await88 

_validator88 
.88 
ValidateAsync88 *
(88* +
request88+ 2
.882 3

RequestDto883 =
,88= >
cancellationToken88? P
)88P Q
is99 
var99 

validation99 
&&99  
!99! "

validation99" ,
.99, -
IsValid99- 4
)994 5
{:: 	
response;; 
.;; $
AddErrorValidationResult;; -
(;;- .

validation;;. 8
);;8 9
;;;9 :
return<< 
response<< 
;<< 
}== 	
if?? 

(?? 
await?? 
_unitOfWork?? 
.?? %
PictureOfTheDayRepository?? 7
.??7 8
GetByDateAsync??8 F
(??F G
request??G N
.??N O

RequestDto??O Y
.??Y Z
Date??Z ^
,??^ _
cancellationToken??` q
)??q r
is@@ 
var@@ 
	pictureDB@@ 
&&@@ 
	pictureDB@@  )
is@@* ,
not@@- 0
null@@1 5
)@@5 6
returnAA 
_mapperAA 
.AA 
MapAA 
<AA 0
$GetPictureOfTheDayResponseHandlerDtoAA C
>AAC D
(AAD E
	pictureDBAAE N
)AAN O
;AAO P
ifCC 

(CC 
awaitCC 
_nasaPortalClientCC #
.CC# $#
GetPictureOfTheDayAsyncCC$ ;
(CC; <
requestCC< C
.CCC D

RequestDtoCCD N
.CCN O
DateCCO S
,CCS T
requestCCU \
.CC\ ]
TrackIdCC] d
,CCd e
cancellationTokenCCf w
)CCw x
isDD 
varDD 
nasaResponseClientDD %
&&DD& (
!DD) *
nasaResponseClientDD* <
.DD< =
IsValidDD= D
(DDD E
)DDE F
)DDF G
{EE 	
varFF 
errorFF 
=FF 
nasaResponseClientFF *
.FF* +
GetErrorFF+ 3
(FF3 4
)FF4 5
.FF5 6
errorFF6 ;
;FF; <
responseGG 
.GG 
SetErrorGG 
(GG 
newGG !
ErrorResponseGG" /
(GG/ 0
errorGG0 5
.GG5 6
codeGG6 :
,GG: ;
errorGG< A
.GGA B
messageGGB I
)GGI J
)GGJ K
;GGK L
returnII 
responseII 
;II 
}JJ 	
varLL 
picutreOfTheDayDBLL 
=LL 
newLL  #
PictureOfTheDayLL$ 3
(LL3 4
nasaResponseClientMM 
.MM 
	CopyrightMM (
,MM( )
nasaResponseClientNN 
.NN 
DateNN #
,NN# $
nasaResponseClientOO 
.OO 
ExplanationOO *
,OO* +
nasaResponseClientPP 
.PP 
HdurlPP $
,PP$ %
nasaResponseClientQQ 
.QQ 
TitleQQ $
,QQ$ %
nasaResponseClientRR 
.RR 
UrlRR "
)RR" #
;RR# $
PublishQueueTT 
(TT 
picutreOfTheDayDBTT &
)TT& '
;TT' (
returnVV 
_mapperVV 
.VV 
MapVV 
<VV 0
$GetPictureOfTheDayResponseHandlerDtoVV ?
>VV? @
(VV@ A
nasaResponseClientVVA S
)VVS T
;VVT U
}WW 
privateYY 
voidYY 
PublishQueueYY 
(YY 
PictureOfTheDayYY -
pictureOfTheDayYY. =
)YY= >
=>YY? A
_setupMessageBrokerZZ 
.ZZ 
ProduceMessageZZ *
(ZZ* +
JsonSerializer[[ 
.[[ 
	Serialize[[ #
([[# $
pictureOfTheDay[[$ 3
)[[3 4
,[[4 5
_configuration\\ 
.\\ &
RabbitQueuePictureOfTheDay\\ 4
(\\4 5
)\\5 6
,\\6 7
_configuration]] 
.]] )
RabbitExchangePictureOfTheDay]] 7
(]]7 8
)]]8 9
,]]9 :
_configuration^^ 
.^^ +
RabbitRoutingKeyPictureOfTheDay^^ 9
(^^9 :
)^^: ;
)^^; <
;^^< =
}__ ˙
ëC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\AstronomyPicture\GetPictureOfTheDay\Dto_\Handler\GetPictureOfTheDayResponseHandlerDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Nasa "
." #
AstronomyPicture# 3
.3 4
GetPictureOfTheDay4 F
;F G
public 
sealed 
class 0
$GetPictureOfTheDayResponseHandlerDto 8
:9 :
BaseResponseDto; J
{ 
public 

string 
	Copyright 
{ 
get !
;! "
set# &
;& '
}( )
public 

DateTime 
Date 
{ 
get 
; 
set  #
;# $
}% &
public		 

string		 
Explanation		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 

string

 
Hdurl

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
public 

string 
Title 
{ 
get 
; 
set "
;" #
}$ %
public 

string 
Url 
{ 
get 
; 
set  
;  !
}" #
} ¯

êC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\AstronomyPicture\GetPictureOfTheDay\Dto_\Handler\GetPictureOfTheDayRequestHandlerDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Nasa "
." #
AstronomyPicture# 3
.3 4
GetPictureOfTheDay4 F
;F G
public 
sealed 
class /
#GetPictureOfTheDayRequestHandlerDto 7
:8 9
IRequest: B
<B C0
$GetPictureOfTheDayResponseHandlerDtoC g
>g h
{ 
public 
/
#GetPictureOfTheDayRequestHandlerDto .
(. /(
GetPictureOfTheDayRequestDto/ K
requestL S
,S T
GuidU Y
trackIdZ a
)a b
{ 

RequestDto		 
=		 
request		 
;		 
TrackId

 
=

 
trackId

 
;

 
} 
public 

Guid 
TrackId 
{ 
get 
; 
set "
;" #
}$ %
public 
(
GetPictureOfTheDayRequestDto '

RequestDto( 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
} ª
ãC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\AstronomyPicture\GetPictureOfTheDay\Dto_\Arguments\GetPictureOfTheDayRequestDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Nasa "
." #
AstronomyPicture# 3
.3 4
GetPictureOfTheDay4 F
;F G
public 
sealed 
class (
GetPictureOfTheDayRequestDto 0
{ 
public 

DateTime 
Date 
{ 
get 
; 
set  #
;# $
}% &
} ¯
áC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\AstronomyPicture\GetAllPictureOfTheDay\Handle_\GetAllPictureOfTheDayHandler.cs
	namespace		 	
Poc		
 
.		 
Nasa		 
.		 
Portal		 
.		 
App		 
.		 
Nasa		 "
.		" #
AstronomyPicture		# 3
.		3 4!
GetAllPictureOfTheDay		4 I
;		I J
public 
sealed 
class (
GetAllPictureOfTheDayHandler 0
:1 2
IRequestHandler3 B
<B C2
&GetAllPictureOfTheDayRequestHandlerDtoC i
,i j4
'GetAllPictureOfTheDayResponseHandlerDto	k í
>
í ì
{ 
private 
readonly 
ILogger 
< (
GetAllPictureOfTheDayHandler 9
>9 :
_logger; B
;B C
private 
readonly 
IUnitOfWork  
_unitOfWork! ,
;, -
private 
readonly 
IMapper 
_mapper $
;$ %
public 
(
GetAllPictureOfTheDayHandler '
( 
ILogger 
< (
GetAllPictureOfTheDayHandler ,
>, -
logger. 4
,4 5
IUnitOfWork 

unitOfWork 
, 
IMapper 
mapper 
) 
{ 
_logger 
= 
logger 
; 
_unitOfWork 
= 

unitOfWork  
;  !
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< 3
'GetAllPictureOfTheDayResponseHandlerDto =
>= >
Handle? E
(E F2
&GetAllPictureOfTheDayRequestHandlerDto .
request/ 6
,6 7
CancellationToken8 I
cancellationTokenJ [
)[ \
{ 
_logger   
.   
LogInformation   
(   
$str   B
)  B C
;  C D
var"" 
response"" 
="" 
new"" 3
'GetAllPictureOfTheDayResponseHandlerDto"" B
(""B C
)""C D
;""D E
if$$ 

($$ 
await$$ 
_unitOfWork$$ 
.$$ %
PictureOfTheDayRepository$$ 7
.$$7 8
GetAllAsync$$8 C
($$C D
cancellationToken$$D U
)$$U V
is%% 
var%% 
picture%% 
&&%% 
picture%% %
is%%& (
null%%) -
)%%- .
{&& 	
response'' 
.'' 
SetError'' 
('' 
new'' !
ErrorResponse''" /
(''/ 0
MessageValidation(( !
.((! "
NoDataFound((" -
.((- .
code((. 2
,((2 3
MessageValidation)) !
.))! "
NoDataFound))" -
.))- .
description)). 9
)))9 :
))): ;
;)); <
return++ 
response++ 
;++ 
},, 	
response.. 
... 
PicturesOfTheDay.. !
=.." #
_mapper..$ +
...+ ,
Map.., /
<../ 0
IList..0 5
<..5 6
PictureOfTheDay..6 E
>..E F
,..F G
IList..H M
<..M N,
 GetAllPictureOfTheDayResponseDto..N n
>..n o
>..o p
(..p q
picture..q x
)..x y
;..y z
return// 
response// 
;// 
}00 
}11 Ø
ñC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\AstronomyPicture\GetAllPictureOfTheDay\Dto_\Handler\GetAllPictureOfTheDayRequestHandlerDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Nasa "
." #
AstronomyPicture# 3
.3 4!
GetAllPictureOfTheDay4 I
;I J
public 
sealed 
class 2
&GetAllPictureOfTheDayRequestHandlerDto :
:; <
IRequest= E
<E F3
'GetAllPictureOfTheDayResponseHandlerDtoF m
>m n
{ 
public 
2
&GetAllPictureOfTheDayRequestHandlerDto 1
(1 2
Guid2 6
trackId7 >
)> ?
=>@ B
TrackId 
= 
trackId 
; 
public

 

Guid

 
TrackId

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
} å
ôC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Nasa\AstronomyPicture\GetAllPictureOfTheDay\Dto_\Arguments\GetAllPictureOfTheDayResponseHandlerDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
Nasa "
." #
AstronomyPicture# 3
.3 4!
GetAllPictureOfTheDay4 I
;I J
public 
sealed 
class 3
'GetAllPictureOfTheDayResponseHandlerDto ;
:< =
BaseResponseDto> M
{ 
public 

IList 
< ,
 GetAllPictureOfTheDayResponseDto 1
>1 2
PicturesOfTheDay3 C
{D E
getF I
;I J
setK N
;N O
}P Q
} 
public

 
sealed

 
class

 ,
 GetAllPictureOfTheDayResponseDto

 4
{ 
public 

Guid 
Id 
{ 
get 
; 
set 
; 
}  
public 

string 
	Copyright 
{ 
get !
;! "
set# &
;& '
}( )
public 

DateTime 
Date 
{ 
get 
; 
set  #
;# $
}% &
public 

string 
Explanation 
{ 
get  #
;# $
set% (
;( )
}* +
public 

string 
Hdurl 
{ 
get 
; 
set "
;" #
}$ %
public 

string 
Title 
{ 
get 
; 
set "
;" #
}$ %
public 

string 
Url 
{ 
get 
; 
set  
;  !
}" #
} Ω#
SC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\HealthCheck\MysqlHealthCheck.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
HealthCheck )
;) *
public 
sealed 
class 
MysqlHealthCheck $
:% &
IHealthCheck' 3
{ 
private 
readonly 
string 
_connectionString -
;- .
private		 
readonly		 
string		 
_sql		  
;		  !
private

 
readonly

 
Action

 
<

 
MySqlConnection

 +
>

+ ,+
_beforeOpenConnectionConfigurer

- L
;

L M
public 

MysqlHealthCheck 
( 
string "!
mySqlConnectionstring# 8
,8 9
string: @
sqlA D
,D E
ActionF L
<L M
MySqlConnectionM \
>\ ]*
beforeOpenConnectionConfigurer^ |
=} ~
null	 É
)
É Ñ
{ 
_connectionString 
= !
mySqlConnectionstring 1
??2 4
throw5 :
new; >!
ArgumentNullException? T
(T U
nameofU [
([ \!
mySqlConnectionstring\ q
)q r
)r s
;s t
_sql 
= 
sql 
?? 
throw 
new !
ArgumentNullException  5
(5 6
nameof6 <
(< =
sql= @
)@ A
)A B
;B C+
_beforeOpenConnectionConfigurer '
=( )*
beforeOpenConnectionConfigurer* H
;H I
} 
public 

async 
Task 
< 
HealthCheckResult '
>' (
CheckHealthAsync) 9
(9 :
HealthCheckContext: L
contextM T
,T U
CancellationTokenV g
cth j
=k l
defaultm t
)t u
{ 
string 
baseName 
= 
$str !
;! "
try 
{ 	
using 
( 
var 

connection !
=" #
new$ '
MySqlConnection( 7
(7 8
_connectionString8 I
)I J
)J K
{ +
_beforeOpenConnectionConfigurer /
?/ 0
.0 1
Invoke1 7
(7 8

connection8 B
)B C
;C D
await 

connection  
.  !
	OpenAsync! *
(* +
ct+ -
)- .
;. /
using 
( 
var 
command "
=# $

connection% /
./ 0
CreateCommand0 =
(= >
)> ?
)? @
{ 
if   
(   
ct   
.   #
IsCancellationRequested   2
)  2 3
return!! 
new!! "
HealthCheckResult!!# 4
(!!4 5
context!!5 <
.!!< =
Registration!!= I
.!!I J
FailureStatus!!J W
)!!W X
;!!X Y
command## 
.## 
CommandText## '
=##( )
_sql##* .
;##. /
await$$ 
command$$ !
.$$! "
ExecuteScalarAsync$$" 4
($$4 5
ct$$5 7
)$$7 8
;$$8 9
}%% 
return'' 
HealthCheckResult'' (
.''( )
Healthy'') 0
(''0 1
baseName''1 9
)''9 :
;'': ;
}(( 
})) 	
catch** 
(** 
	Exception** 
ex** 
)** 
{++ 	
return,, 
new,, 
HealthCheckResult,, (
(,,( )
context,,) 0
.,,0 1
Registration,,1 =
.,,= >
FailureStatus,,> K
,,,K L
	exception,,M V
:,,V W
ex,,X Z
,,,Z [
description,,\ g
:,,g h
$",,i k
{,,k l
baseName,,l t
},,t u
$str,,u x
{,,x y
ex,,y {
.,,{ |
Message	,,| É
}
,,É Ñ
"
,,Ñ Ö
)
,,Ö Ü
;
,,Ü á
}-- 	
}.. 
}// ﬂ%
TC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\HealthCheck\GCInfoHealthCheck.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 
HealthCheck )
;) *
public 
sealed 
class 
GCInfoHealthCheck %
:& '
IHealthCheck( 4
{ 
private 
readonly 
IOptionsMonitor $
<$ %
GCInfoOptions% 2
>2 3
_options4 <
;< =
public

 

GCInfoHealthCheck

 
(

 
IOptionsMonitor

 ,
<

, -
GCInfoOptions

- :
>

: ;
options

< C
)

C D
=>

E G
_options 
= 
options 
; 
public 

Task 
< 
HealthCheckResult !
>! "
CheckHealthAsync# 3
(3 4
HealthCheckContext4 F
contextG N
,N O
CancellationTokenP a
ctb d
=e f
defaultg n
)n o
{ 
try 
{ 	
var 
options 
= 
_options "
." #
Get# &
(& '
context' .
.. /
Registration/ ;
.; <
Name< @
)@ A
;A B
var 
allocatedByte 
= 
GC  "
." #
GetTotalMemory# 1
(1 2
forceFullCollection2 E
:E F
falseG L
)L M
;M N
var 
allocatedMb 
= 
( 
GC !
.! "
GetTotalMemory" 0
(0 1
forceFullCollection1 D
:D E
falseF K
)K L
/M N
$numO T
)T U
/V W
$numX ]
;] ^
var 
msg 
= 
$str (
+) *
allocatedMb+ 6
+7 8
$str9 P
+Q R
allocatedByteS `
;` a
var 
data 
= 
new 

Dictionary %
<% &
string& ,
,, -
object. 4
>4 5
(5 6
)6 7
{ 
{ 
$str *
,* +
allocatedMb, 7
}8 9
,9 :
{ 
$str ,
,, -
allocatedByte. ;
}< =
,= >
{ 
$str +
,+ ,
GC- /
./ 0
CollectionCount0 ?
(? @
$num@ A
)A B
}C D
,D E
{ 
$str +
,+ ,
GC- /
./ 0
CollectionCount0 ?
(? @
$num@ A
)A B
}C D
,D E
{ 
$str +
,+ ,
GC- /
./ 0
CollectionCount0 ?
(? @
$num@ A
)A B
}C D
,D E
} 
; 
var$$ 
result$$ 
=$$ 
allocatedByte$$ &
>=$$' )
options$$* 1
.$$1 2
	Threshold$$2 ;
?$$< =
context$$> E
.$$E F
Registration$$F R
.$$R S
FailureStatus$$S `
:$$a b
HealthStatus$$c o
.$$o p
Healthy$$p w
;$$w x
return&& 
Task&& 
.&& 

FromResult&& "
(&&" #
new&&# &
HealthCheckResult&&' 8
(&&8 9
result'' 
,'' 
description(( 
:(( 
msg((  
,((  !
data)) 
:)) 
data)) 
))) 
))) 
;)) 
}** 	
catch++ 
(++ 
	Exception++ 
ex++ 
)++ 
{,, 	
return-- 
Task-- 
.-- 

FromResult-- "
(--" #
new--# &
HealthCheckResult--' 8
(--8 9
HealthStatus--9 E
.--E F
Degraded--F N
,--N O
	exception--P Y
:--Y Z
ex--[ ]
)--] ^
)--^ _
;--_ `
}.. 	
}// 
}00 
public22 
sealed22 
class22 
GCInfoOptions22 !
{33 
public44 

long44 
	Threshold44 
{44 
get44 
;44  
set44! $
;44$ %
}44& '
=44( )
$num44* /
*440 1
$num442 7
*448 9
$num44: ?
;44? @
}55 ≈
]C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\Extensions\ServiceCollectionExtensions.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 

Extensions (
;( )
public 
static 
class '
ServiceCollectionExtensions /
{ 
public 

static 
void $
AddApisServiceCollection /
(/ 0
this0 4
IServiceCollection5 G
servicesH P
,P Q
IConfigurationR `
configurationa n
)n o
{		 
} 
} èP
VC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.App\AutoMapper\ConfigurationMapping.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
App 
. 

AutoMapper (
;( )
public

 
sealed

 
class

  
ConfigurationMapping

 (
:

) *
Profile

+ 2
{ 
public 
 
ConfigurationMapping 
(  
)  !
{ 
	CreateMap 
< /
#GetPictureOfTheDayResponseClientDto 5
,5 60
$GetPictureOfTheDayResponseHandlerDto7 [
>[ \
(\ ]
)] ^
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Hdurl$ )
,) *
opt+ .
=>/ 1
opt2 5
.5 6
MapFrom6 =
(= >
src> A
=>B D
srcE H
.H I
HdurlI N
)N O
)O P
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Date$ (
,( )
opt* -
=>. 0
opt1 4
.4 5
MapFrom5 <
(< =
src= @
=>A C
srcD G
.G H
DateH L
)L M
)M N
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
	Copyright$ -
,- .
opt/ 2
=>3 5
opt6 9
.9 :
MapFrom: A
(A B
srcB E
=>F H
srcI L
.L M
	CopyrightM V
)V W
)W X
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Explanation$ /
,/ 0
opt1 4
=>5 7
opt8 ;
.; <
MapFrom< C
(C D
srcD G
=>H J
srcK N
.N O
ExplanationO Z
)Z [
)[ \
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Title$ )
,) *
opt+ .
=>/ 1
opt2 5
.5 6
MapFrom6 =
(= >
src> A
=>B D
srcE H
.H I
TitleI N
)N O
)O P
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Url$ '
,' (
opt) ,
=>- /
opt0 3
.3 4
MapFrom4 ;
(; <
src< ?
=>@ B
srcC F
.F G
UrlG J
)J K
)K L
;L M
	CreateMap 
< 
PictureOfTheDay !
,! "0
$GetPictureOfTheDayResponseHandlerDto# G
>G H
(H I
)I J
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Hdurl$ )
,) *
opt+ .
=>/ 1
opt2 5
.5 6
MapFrom6 =
(= >
src> A
=>B D
srcE H
.H I
HdUrlI N
)N O
)O P
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Date$ (
,( )
opt* -
=>. 0
opt1 4
.4 5
MapFrom5 <
(< =
src= @
=>A C
srcD G
.G H
PictureDateH S
)S T
)T U
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
	Copyright$ -
,- .
opt/ 2
=>3 5
opt6 9
.9 :
MapFrom: A
(A B
srcB E
=>F H
srcI L
.L M
	CopyrightM V
)V W
)W X
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Explanation$ /
,/ 0
opt1 4
=>5 7
opt8 ;
.; <
MapFrom< C
(C D
srcD G
=>H J
srcK N
.N O
ExplanationO Z
)Z [
)[ \
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Title$ )
,) *
opt+ .
=>/ 1
opt2 5
.5 6
MapFrom6 =
(= >
src> A
=>B D
srcE H
.H I
TitleI N
)N O
)O P
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Url$ '
,' (
opt) ,
=>- /
opt0 3
.3 4
MapFrom4 ;
(; <
src< ?
=>@ B
srcC F
.F G
UrlG J
)J K
)K L
;L M
	CreateMap 
< 
PictureOfTheDay !
,! ",
 GetAllPictureOfTheDayResponseDto# C
>C D
(D E
)E F
. 
	ForMember 
( 
dest 
=> 
dest #
.# $
Hdurl$ )
,) *
opt+ .
=>/ 1
opt2 5
.5 6
MapFrom6 =
(= >
src> A
=>B D
srcE H
.H I
HdUrlI N
)N O
)O P
.   
	ForMember   
(   
dest   
=>   
dest   #
.  # $
Date  $ (
,  ( )
opt  * -
=>  . 0
opt  1 4
.  4 5
MapFrom  5 <
(  < =
src  = @
=>  A C
src  D G
.  G H
PictureDate  H S
)  S T
)  T U
.!! 
	ForMember!! 
(!! 
dest!! 
=>!! 
dest!! #
.!!# $
	Copyright!!$ -
,!!- .
opt!!/ 2
=>!!3 5
opt!!6 9
.!!9 :
MapFrom!!: A
(!!A B
src!!B E
=>!!F H
src!!I L
.!!L M
	Copyright!!M V
)!!V W
)!!W X
."" 
	ForMember"" 
("" 
dest"" 
=>"" 
dest"" #
.""# $
Explanation""$ /
,""/ 0
opt""1 4
=>""5 7
opt""8 ;
.""; <
MapFrom""< C
(""C D
src""D G
=>""H J
src""K N
.""N O
Explanation""O Z
)""Z [
)""[ \
.## 
	ForMember## 
(## 
dest## 
=>## 
dest## #
.### $
Title##$ )
,##) *
opt##+ .
=>##/ 1
opt##2 5
.##5 6
MapFrom##6 =
(##= >
src##> A
=>##B D
src##E H
.##H I
Title##I N
)##N O
)##O P
.$$ 
	ForMember$$ 
($$ 
dest$$ 
=>$$ 
dest$$ #
.$$# $
Url$$$ '
,$$' (
opt$$) ,
=>$$- /
opt$$0 3
.$$3 4
MapFrom$$4 ;
($$; <
src$$< ?
=>$$@ B
src$$C F
.$$F G
Url$$G J
)$$J K
)$$K L
;$$L M
	CreateMap'' 
<'' 
PictureOfTheDay'' !
,''! " 
PictureOfTheDayRedis''# 7
>''7 8
(''8 9
)''9 :
.(( 
	ForMember(( 
((( 
dest(( 
=>(( 
dest(( #
.((# $
HdUrl(($ )
,(() *
opt((+ .
=>((/ 1
opt((2 5
.((5 6
MapFrom((6 =
(((= >
src((> A
=>((B D
src((E H
.((H I
HdUrl((I N
)((N O
)((O P
.)) 
	ForMember)) 
()) 
dest)) 
=>)) 
dest)) #
.))# $
PictureDate))$ /
,))/ 0
opt))1 4
=>))5 7
opt))8 ;
.)); <
MapFrom))< C
())C D
src))D G
=>))H J
src))K N
.))N O
PictureDate))O Z
)))Z [
)))[ \
.** 
	ForMember** 
(** 
dest** 
=>** 
dest** #
.**# $
	Copyright**$ -
,**- .
opt**/ 2
=>**3 5
opt**6 9
.**9 :
MapFrom**: A
(**A B
src**B E
=>**F H
src**I L
.**L M
	Copyright**M V
)**V W
)**W X
.++ 
	ForMember++ 
(++ 
dest++ 
=>++ 
dest++ #
.++# $
Explanation++$ /
,++/ 0
opt++1 4
=>++5 7
opt++8 ;
.++; <
MapFrom++< C
(++C D
src++D G
=>++H J
src++K N
.++N O
Explanation++O Z
)++Z [
)++[ \
.,, 
	ForMember,, 
(,, 
dest,, 
=>,, 
dest,, #
.,,# $
Title,,$ )
,,,) *
opt,,+ .
=>,,/ 1
opt,,2 5
.,,5 6
MapFrom,,6 =
(,,= >
src,,> A
=>,,B D
src,,E H
.,,H I
Title,,I N
),,N O
),,O P
.-- 
	ForMember-- 
(-- 
dest-- 
=>-- 
dest-- #
.--# $
Url--$ '
,--' (
opt--) ,
=>--- /
opt--0 3
.--3 4
MapFrom--4 ;
(--; <
src--< ?
=>--@ B
src--C F
.--F G
Url--G J
)--J K
)--K L
;--L M
}.. 
}// 