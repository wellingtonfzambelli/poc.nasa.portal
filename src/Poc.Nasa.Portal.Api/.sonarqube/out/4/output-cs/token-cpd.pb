­4
BC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Workers\Program.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Workers !
;! "
public 
class 
Program 
{ 
private 
static 
string 
EnvironmentName )
=>* ,
Environment- 8
.8 9"
GetEnvironmentVariable9 O
(O P
$strP h
)h i
;i j
private 
static 
IConfiguration !
Configuration" /
{0 1
get2 5
;5 6
}7 8
=9 :
new; > 
ConfigurationBuilder? S
(S T
)T U
. #
AddEnvironmentVariables '
(' (
)( )
. 
AddJsonFile 
( 
$str .
,. /
optional0 8
:8 9
true: >
)> ?
. 
AddJsonFile 
( 
$" 
$str *
{* +
EnvironmentName+ :
}: ;
$str; @
"@ A
,A B
optionalC K
:K L
trueM Q
)Q R
. 
Build 
( 
) 
; 
public 

static 
async 
Task 
Main !
(! "
string" (
[( )
]) *
args+ /
)/ 0
{ 
var 
host 
= 
CreateHostBuilder $
($ %
args% )
)) *
.* +
Build+ 0
(0 1
)1 2
;2 3
await 
host 
. 
RunAsync 
( 
) 
; 
} 
public 

static 
IHostBuilder 
CreateHostBuilder 0
(0 1
string1 7
[7 8
]8 9
args: >
)> ?
=>@ B
Host 
.  
CreateDefaultBuilder !
(! "
args" &
)& '
.  	 
%
ConfigureAppConfiguration  
 #
(  # $
builder  $ +
=>  , .
{!!	 

builder"" 
."" 
Sources"" 
."" 
Clear"" "
(""" #
)""# $
;""$ %
builder## 
.## 
AddConfiguration## %
(##% &
Configuration##& 3
)##3 4
;##4 5
}$$	 

)$$
 
.%% 	
ConfigureServices%%	 
(%% 
(%% 
hostContext%% '
,%%' (
services%%) 1
)%%1 2
=>%%3 5
{&& 	
services'' 
.'' 
AddHostedService'' %
<''% &#
PictureOfTheDayConsumer''& =
>''= >
(''> ?
)''? @
;''@ A
services(( 
.(( 
	AddScoped(( 
<(( 
ISetupMessageBroker(( 2
,((2 3
SetupMessageBroker((4 F
>((F G
(((G H
)((H I
;((I J
services)) 
.)) 
	AddScoped)) 
<)) 
IUnitOfWork)) *
,))* +

UnitOfWork)), 6
>))6 7
())7 8
)))8 9
;))9 :
services** 
.** 
	AddScoped** 
<** 
ICacheService** ,
,**, -
CacheService**. :
>**: ;
(**; <
)**< =
;**= >
AddRabbitMQ,, 
(,, 
services,,  
,,,  !
Configuration,," /
),,/ 0
;,,0 1
AddMySQL-- 
(-- 
services-- 
,-- 
Configuration-- ,
)--, -
;--- .
AddRedis.. 
(.. 
services.. 
,.. 
Configuration.. ,
).., -
;..- .
}// 	
)//	 

;//
 
static11 

void11 
AddRabbitMQ11 
(11 
IServiceCollection11 .
services11/ 7
,117 8
IConfiguration119 G
config11H N
)11N O
=>11P R
services22 
.22 
	AddScoped22 
<22 
ISetupMessageBroker22 .
>22. /
(22/ 0
p220 1
=>222 4
new33 
SetupMessageBroker33 "
(33" #
config44 
.44 
RabbitHostname44 %
(44% &
)44& '
,44' (
config55 
.55 
RabbitVHost55 "
(55" #
)55# $
,55$ %
config66 
.66 
RabbitUsername66 %
(66% &
)66& '
,66' (
config77 
.77 
RabbitPassord77 $
(77$ %
)77% &
)77& '
)88 	
;88	 

static:: 

void:: 
AddMySQL:: 
(:: 
IServiceCollection:: +
services::, 4
,::4 5
IConfiguration::6 D
config::E K
)::K L
{;; 
string<< 

connection<< 
=<< 
config<< "
.<<" #
ConnectionString<<# 3
(<<3 4
)<<4 5
;<<5 6
var== 
serverVersion== 
=== 
new== 
MySqlServerVersion==  2
(==2 3
new==3 6
Version==7 >
(==> ?
$num==? @
,==@ A
$num==B C
,==C D
$num==E G
)==G H
)==H I
;==I J
services>> 
.>> 
AddDbContext>> 
<>> 
NasaPortalContext>> /
>>>/ 0
(>>0 1
o>>1 2
=>>>3 5
o>>6 7
.>>7 8
UseMySql>>8 @
(>>@ A

connection>>A K
,>>K L
serverVersion>>M Z
)>>Z [
)>>[ \
;>>\ ]
}?? 
staticAA 

voidAA 
AddRedisAA 
(AA 
IServiceCollectionAA +
servicesAA, 4
,AA4 5
IConfigurationAA6 D
configAAE K
)AAK L
{BB 
varCC 
providerCC 
=CC 
newCC #
RedisConnectionProviderCC 2
(CC2 3
configCC3 9
.CC9 :
RedisServerCC: E
(CCE F
)CCF G
)CCG H
;CCH I
servicesDD 
.DD 
AddSingletonDD 
(DD 
providerDD &
)DD& '
;DD' (
}EE 
}FF Ê<
lC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Workers\Consumers\PictureOfTheDay\PictureOfTheDayConsumer.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Workers !
.! "
	Consumers" +
.+ ,
PictureOfTheDay, ;
;; <
public 
sealed 
class #
PictureOfTheDayConsumer +
:, -
IHostedService. <
{ 
private 
readonly 
ISetupMessageBroker (
_setupMessageBroker) <
;< =
private 
readonly 
ICacheService "
_cacheService# 0
;0 1
private 
readonly 
IConfiguration #
_configuration$ 2
;2 3
private 
readonly 
IUnitOfWork  
_unitOfWork! ,
;, -
public 
#
PictureOfTheDayConsumer "
( 
IConfiguration 
configuration $
,$ %
ICacheService 
cacheService "
," #
ISetupMessageBroker 
setupMessageBroker .
,. /
IUnitOfWork 

unitOfWork 
) 
{ 
_setupMessageBroker 
= 
setupMessageBroker 0
;0 1
_cacheService 
= 
cacheService $
;$ %
_configuration 
= 
configuration &
;& '
_unitOfWork   
=   

unitOfWork    
;    !
}!! 
public## 

async## 
Task## 

StartAsync##  
(##  !
CancellationToken##! 2
cancellationToken##3 D
)##D E
{$$ 
while%% 
(%% 
true%% 
)%% 
{&& 	
Console'' 
.'' 
	WriteLine'' 
('' 
$"''  
$str''  7
{''7 8
DateTime''8 @
.''@ A
Now''A D
}''D E
$str''E I
"''I J
)''J K
;''K L
try)) 
{** 
if++ 
(++ 
_setupMessageBroker++ '
.++' (
ConsumeMessage++( 6
(++6 7
_configuration++7 E
.++E F&
RabbitQueuePictureOfTheDay++F `
(++` a
)++a b
)++b c
is,, 
var,, 
message,, "
&&,,# %
message,,& -
is,,. 0
null,,1 5
),,5 6
{-- 
await.. 
Task.. 
... 
Delay.. $
(..$ %
_configuration..% 3
...3 4&
WaitInMillisecondsConsumer..4 N
(..N O
)..O P
)..P Q
;..Q R
continue// 
;// 
}00 
var22 
pictureOfTheDayMsg22 &
=22' (
JsonSerializer22) 7
.227 8
Deserialize228 C
<22C D
PictureOfTheDayMsg22D V
>22V W
(22W X
message22X _
)22_ `
;22` a
if44 
(44 
await44 
_unitOfWork44 %
.44% &%
PictureOfTheDayRepository44& ?
.44? @
GetByDateAsync44@ N
(44N O
pictureOfTheDayMsg44O a
.44a b
PictureDate44b m
,44m n
cancellationToken	44o €
)
44€ 
is55 
var55 
	pictureDB55 $
&&55% '
	pictureDB55( 1
is552 4
not555 8
null559 =
)55= >
continue66 
;66 
Guid88 
	pictureId88 
=88  
await88! &
SaveOnDatabaseAsync88' :
(88: ;
pictureOfTheDayMsg88; M
,88M N
cancellationToken88O `
)88` a
;88a b
await:: 
_cacheService:: #
.::# $
InsertAsync::$ /
<::/ 0 
PictureOfTheDayRedis::0 D
>::D E
(::E F
new;;  
PictureOfTheDayRedis;; ,
{<< 
Id== 
=== 
	pictureId== &
,==& '
HdUrl>> 
=>> 
pictureOfTheDayMsg>>  2
.>>2 3
HdUrl>>3 8
,>>8 9
	Copyright?? !
=??" #
pictureOfTheDayMsg??$ 6
.??6 7
	Copyright??7 @
,??@ A
Explanation@@ #
=@@$ %
pictureOfTheDayMsg@@& 8
.@@8 9
Explanation@@9 D
,@@D E
PictureDateAA #
=AA$ %
pictureOfTheDayMsgAA& 8
.AA8 9
PictureDateAA9 D
,AAD E
TitleBB 
=BB 
pictureOfTheDayMsgBB  2
.BB2 3
TitleBB3 8
,BB8 9
UrlCC 
=CC 
pictureOfTheDayMsgCC 0
.CC0 1
UrlCC1 4
}DD 
)DD 
;DD 
}EE 
catchFF 
(FF 
	ExceptionFF 
exFF 
)FF  
{GG 
ConsoleHH 
.HH 
	WriteLineHH !
(HH! "
$"HH" $
$strHH$ 4
{HH4 5
exHH5 7
.HH7 8
MessageHH8 ?
}HH? @
"HH@ A
)HHA B
;HHB C
}II 
}JJ 	
}KK 
privateMM 
asyncMM 
TaskMM 
<MM 
GuidMM 
>MM 
SaveOnDatabaseAsyncMM 0
(MM0 1
PictureOfTheDayMsgMM1 C
msgMMD G
,MMG H
CancellationTokenMMI Z
ctMM[ ]
)MM] ^
{NN 
ConsoleOO 
.OO 
	WriteLineOO 
(OO 
$strOO 2
)OO2 3
;OO3 4
varQQ 
pictureQQ 
=QQ 
newQQ 
DomainQQ  
.QQ  !
ModelsQQ! '
.QQ' ($
PictureOfTheDayAggregateQQ( @
.QQ@ A
PictureOfTheDayQQA P
(RR 
msgSS 
.SS 
	CopyrightSS !
,SS! "
msgTT 
.TT 
PictureDateTT #
,TT# $
msgUU 
.UU 
ExplanationUU #
.UU# $
TruncateUU$ ,
(UU, -
$numUU- 1
)UU1 2
,UU2 3
msgVV 
.VV 
HdUrlVV 
.VV 
TruncateVV &
(VV& '
$numVV' +
)VV+ ,
,VV, -
msgWW 
.WW 
TitleWW 
,WW 
msgXX 
.XX 
UrlXX 
.XX 
TruncateXX $
(XX$ %
$numXX% )
)XX) *
)YY 
;YY 
await[[ 
_unitOfWork[[ 
.[[ %
PictureOfTheDayRepository[[ 3
.[[3 4
CreateAsync[[4 ?
([[? @
picture[[@ G
,[[G H
ct[[I K
)[[K L
;[[L M
await\\ 
_unitOfWork\\ 
.\\ 
	SaveAsync\\ #
(\\# $
ct\\$ &
)\\& '
;\\' (
return^^ 
picture^^ 
.^^ 
Id^^ 
;^^ 
}__ 
publicaa 

asyncaa 
Taskaa 
	StopAsyncaa 
(aa  
CancellationTokenaa  1
cancellationTokenaa2 C
)aaC D
{bb 
Consolecc 
.cc 
	WriteLinecc 
(cc 
$strcc 4
)cc4 5
;cc5 6
Consoledd 
.dd 
	WriteLinedd 
(dd 
$"dd 
{dd 
DateTimedd %
.dd% &
Nowdd& )
}dd) *
"dd* +
)dd+ ,
;dd, -
}ee 
}ff 