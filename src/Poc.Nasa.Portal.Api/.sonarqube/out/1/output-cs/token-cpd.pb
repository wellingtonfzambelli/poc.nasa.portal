¨
dC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Integration\Shared\HttpClientBase\IBaseHttpClient.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Integration %
.% &
Shared& ,
., -
HttpClientBase- ;
;; <
public 
	interface 
IBaseHttpClient  
{ 
Task 
< 	
HttpResponseMessage	 
> 
GetAsync &
( 
string 
endpoint 
, 
IReadOnlyDictionary 
< 
string "
," #
string$ *
>* +
queryStrings, 8
,8 9
Guid		 
trackId		 
,		 
CancellationToken

 
ct

 
) 
; 
Task 
< 	
HttpResponseMessage	 
> 
GetAsync &
( 
string 
endpoint 
, 
IReadOnlyDictionary 
< 
string "
," #
IEnumerable$ /
</ 0
string0 6
>6 7
>7 8
headers9 @
,@ A
IReadOnlyDictionary 
< 
string "
," #
string$ *
>* +
queryStrings, 8
,8 9
Guid 
trackId 
, 
CancellationToken 
ct 
) 
; 
} Á2
cC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Integration\Shared\HttpClientBase\BaseHttpClient.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Integration %
.% &
Shared& ,
., -
HttpClientBase- ;
;; <
public		 
sealed		 
class		 
BaseHttpClient		 "
:		# $
IBaseHttpClient		% 4
{

 
private 
readonly 

HttpClient 
_httpClient  +
;+ ,
private 
readonly 
ILogger 
< 
BaseHttpClient +
>+ ,
_logger- 4
;4 5
public 

BaseHttpClient 
( 

HttpClient $

httpClient% /
,/ 0
ILogger1 8
<8 9
BaseHttpClient9 G
>G H
loggerI O
)O P
{ 
_httpClient 
= 

httpClient  
;  !
_logger 
= 
logger 
; 
} 
public 

async 
Task 
< 
HttpResponseMessage )
>) *
GetAsync+ 3
( 
string 

requestUri 
, 
IReadOnlyDictionary 
< 
string "
," #
string$ *
>* +
queryStrings, 8
,8 9
Guid 
trackId 
, 
CancellationToken 
ct 
) 
{ 
var 
	stopwatch 
= 
new 
	Stopwatch %
(% &
)& '
;' (
	stopwatch 
. 
Start 
( 
) 
; 
var 
urlFull 
= 
$" 
{ 
_httpClient $
.$ %
BaseAddress% 0
}0 1
{1 2

requestUri2 <
}< =
"= >
;> ?
_logger   
.   
LogInformation   
(   
$"   !
$str  ! *
{  * +
trackId  + 2
}  2 3
$str  3 ?
{  ? @
urlFull  @ G
}  G H
"  H I
)  I J
;  J K
HttpResponseMessage"" 
responseMessage"" +
="", -
null"". 2
;""2 3
if$$ 

($$ 
queryStrings$$ 
is$$ 
null$$  
)$$  !
responseMessage%% 
=%% 
await%% #
new%%$ '
	ValueTask%%( 1
<%%1 2
HttpResponseMessage%%2 E
>%%E F
(%%F G
_httpClient&& 
.&& 
GetAsync&&  
(&&  !
urlFull&&! (
,&&( ) 
HttpCompletionOption&&* >
.&&> ?
ResponseHeadersRead&&? R
,&&R S
ct&&T V
)&&V W
)&&W X
;&&X Y
else'' 
responseMessage(( 
=(( 
await(( #
new(($ '
	ValueTask((( 1
<((1 2
HttpResponseMessage((2 E
>((E F
(((F G
_httpClient)) 
.)) 
GetAsync))  
())  !
QueryHelpers))! -
.))- .
AddQueryString)). <
())< =
urlFull))= D
,))D E
queryStrings))F R
)))R S
,))S T
ct))U W
)))W X
)))X Y
;))Y Z
if++ 

(++ 
ct++ 
.++ #
IsCancellationRequested++ &
)++& '
return,, 
new,, 
HttpResponseMessage,, *
(,,* +
HttpStatusCode,,+ 9
.,,9 :
InternalServerError,,: M
),,M N
;,,N O
	stopwatch.. 
... 
Stop.. 
(.. 
).. 
;.. 
_logger// 
.// 
LogInformation// 
(// 
$"// !
$str//! *
{//* +
trackId//+ 2
}//2 3
$str//3 F
{//F G
JsonSerializer//G U
.//U V
	Serialize//V _
(//_ `
responseMessage//` o
)//o p
}//p q
$str//q |
{//| }
	stopwatch	//} †
.
//† ‡
Elapsed
//‡ Ž
}
//Ž 
"
// 
)
// ‘
;
//‘ ’
return11 
responseMessage11 
;11 
}22 
public44 

async44 
Task44 
<44 
HttpResponseMessage44 )
>44) *
GetAsync44+ 3
(55 
string66 

requestUri66 
,66 
IReadOnlyDictionary77 
<77 
string77 "
,77" #
IEnumerable77$ /
<77/ 0
string770 6
>776 7
>777 8
headers779 @
,77@ A
IReadOnlyDictionary88 
<88 
string88 "
,88" #
string88$ *
>88* +
queryStrings88, 8
,888 9
Guid99 
trackId99 
,99 
CancellationToken:: 
ct:: 
);; 
{<< 
foreach== 
(== 
var== 
header== 
in== 
headers== &
)==& '
{>> 	
if?? 
(?? 
_httpClient?? 
.?? !
DefaultRequestHeaders?? 1
.??1 2
Contains??2 :
(??: ;
header??; A
.??A B
Key??B E
)??E F
)??F G
_httpClient@@ 
.@@ !
DefaultRequestHeaders@@ 1
.@@1 2
Remove@@2 8
(@@8 9
header@@9 ?
.@@? @
Key@@@ C
)@@C D
;@@D E
_httpClientBB 
.BB !
DefaultRequestHeadersBB -
.BB- .
AddBB. 1
(BB1 2
headerBB2 8
.BB8 9
KeyBB9 <
,BB< =
headerBB> D
.BBD E
ValueBBE J
)BBJ K
;BBK L
}CC 	
returnEE 
awaitEE 
GetAsyncEE 
(EE 

requestUriEE (
,EE( )
queryStringsEE* 6
,EE6 7
trackIdEE8 ?
,EE? @
ctEEA C
)EEC D
;EED E
}FF 
}GG Ç'
ZC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Integration\NasaPortal\NasaPortalClient.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Integration %
.% &

NasaPortal& 0
;0 1
public 
sealed 
class 
NasaPortalClient $
:% &
INasaPortalClient' 8
{ 
private		 
readonly		 
IBaseHttpClient		 $
_baseHttpClient		% 4
;		4 5
private

 
readonly

 
ILogger

 
<

 
NasaPortalClient

 -
>

- .
_logger

/ 6
;

6 7
private 
readonly 
string 
_apiKey #
;# $
public 

NasaPortalClient 
( 
IBaseHttpClient 
baseHttpClient &
,& '
ILogger 
< 
NasaPortalClient  
>  !
logger" (
,( )
string 
apiKey 
) 
{ 
_logger 
= 
logger 
; 
_baseHttpClient 
= 
baseHttpClient (
;( )
_apiKey 
= 
apiKey 
; 
} 
public 

async 
Task 
< /
#GetPictureOfTheDayResponseClientDto 9
>9 :#
GetPictureOfTheDayAsync; R
(R S
DateTime 
dateOfPicture 
, 
Guid  $
trackId% ,
,, -
CancellationToken. ?
ct@ B
)B C
{ 
string 
enpoint 
= 
$str )
;) *
try 
{ 	
var   
queryStrings   
=   
new   "

Dictionary  # -
<  - .
string  . 4
,  4 5
string  6 <
>  < =
(  = >
)  > ?
{!! 
{"" 
$str"" 
,"" 
_apiKey"" $
}""% &
,""& '
{## 
$str## 
,## 
dateOfPicture## '
.##' (
ToString##( 0
(##0 1
$str##1 =
)##= >
}##? @
}$$ 
;$$ 
var&& 
responseMessage&& 
=&&  !
await&&" '
_baseHttpClient&&( 7
.&&7 8
GetAsync&&8 @
('' 
enpoint(( 
,(( 
queryStrings)) 
,)) 
trackId** 
,** 
ct++ 
),, 
;,, 
var.. 
jsonResponse.. 
=.. 
await.. $
responseMessage..% 4
...4 5
Content..5 <
...< =
ReadAsStringAsync..= N
(..N O
)..O P
;..P Q
if00 
(00 
responseMessage00 
.00  
IsSuccessStatusCode00  3
)003 4
return11 
JsonConvert11 "
.11" #
DeserializeObject11# 4
<114 5/
#GetPictureOfTheDayResponseClientDto115 X
>11X Y
(11Y Z
jsonResponse11Z f
)11f g
;11g h
return33 
ExtractBadRequest33 $
(33$ %
jsonResponse33% 1
,331 2
trackId333 :
)33: ;
;33; <
}44 	
catch55 
(55 
	Exception55 
ex55 
)55 
{66 	
_logger77 
.77 
LogError77 
(77 
ex77 
,77  
$"77! #
$str77# ,
{77, -
trackId77- 4
}774 5
"775 6
)776 7
;777 8
throw88 
ex88 
;88 
}99 	
}:: 
private<< /
#GetPictureOfTheDayResponseClientDto<< /
ExtractBadRequest<<0 A
(<<A B
string<<B H
jsonResponse<<I U
,<<U V
Guid<<W [
trackId<<\ c
)<<c d
{== 
_logger>> 
.>> 

LogWarning>> 
(>> 
jsonResponse>> '
,>>' (
$">>) +
$str>>+ 4
{>>4 5
trackId>>5 <
}>>< =
">>= >
)>>> ?
;>>? @
var@@ 
responseErro@@ 
=@@ 
JsonConvert@@ &
.@@& '
DeserializeObject@@' 8
<@@8 9#
NasaBadRequestClientDto@@9 P
>@@P Q
(@@Q R
jsonResponse@@R ^
)@@^ _
;@@_ `
varBB 
responseBB 
=BB 
newBB /
#GetPictureOfTheDayResponseClientDtoBB >
(BB> ?
)BB? @
;BB@ A
responseCC 
.CC 
SetErrorCC 
(CC 
responseErroCC &
)CC& '
;CC' (
returnEE 
responseEE 
;EE 
}FF 
}GG ß
[C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Integration\NasaPortal\INasaPortalClient.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Integration %
.% &

NasaPortal& 0
;0 1
public 
	interface 
INasaPortalClient "
{ 
Task 
< 	/
#GetPictureOfTheDayResponseClientDto	 ,
>, -#
GetPictureOfTheDayAsync. E
(E F
DateTime 
dateOfPicture 
, 
Guid  $
trackId% ,
,, -
CancellationToken. ?
ct@ B
)B C
;C D
} ¶	
hC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Integration\NasaPortal\Dto_\NasaResponseBaseClientDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Integration %
.% &

NasaPortal& 0
;0 1
public 
abstract 
class %
NasaResponseBaseClientDto /
{ 
	protected #
NasaBadRequestClientDto %

BadRequest& 0
{1 2
get3 6
;6 7
private8 ?
set@ C
;C D
}E F
public 

void 
SetError 
( #
NasaBadRequestClientDto 0
error1 6
)6 7
=>8 :

BadRequest 
= 
error 
; 
public

 
#
NasaBadRequestClientDto

 "
GetError

# +
(

+ ,
)

, -
=>

. 0

BadRequest 
; 
public 

bool 
IsValid 
( 
) 
=> 

BadRequest 
is 
null 
; 
} ó
fC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Integration\NasaPortal\Dto_\NasaBadRequestClientDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Integration %
.% &

NasaPortal& 0
;0 1
public 
sealed 
class #
NasaBadRequestClientDto +
{ 
public 

NasaErrorClientDto 
error #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
public 
sealed 
class 
NasaErrorClientDto &
{		 
public

 

string

 
code

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
public 

string 
message 
{ 
get 
;  
set! $
;$ %
}& '
} ª
†C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Integration\NasaPortal\Dto_\GetPictureOfTheDay_\GetPictureOfTheDayResponseClientDto.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Integration %
.% &

NasaPortal& 0
;0 1
public 
sealed 
class /
#GetPictureOfTheDayResponseClientDto 7
:8 9%
NasaResponseBaseClientDto: S
{ 
public 

string 
	Copyright 
{ 
get !
;! "
set# &
;& '
}( )
public 

DateTime 
Date 
{ 
get 
; 
set  #
;# $
}% &
public 

string 
Explanation 
{ 
get  #
;# $
set% (
;( )
}* +
public 

string 
Hdurl 
{ 
get 
; 
set "
;" #
}$ %
public		 

string		 
Title		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public

 

string

 
Url

 
{

 
get

 
;

 
set

  
;

  !
}

" #
} 