library libprecmode;

uses
  
  dfpu;




{------------------------ FPU precision mode ----------------------------}



procedure damath_setpmExtended();  cdecl; export;
begin
    SetPrecisionMode(pmExtended);  
end;


procedure damath_setpmDouble();  cdecl; export;
begin
  SetPrecisionMode(pmDouble);
end;

function damath_GetPrecisionMode(): longint;  cdecl; export;
var pm: longint;
var P: TFPUPrecisionMode;
begin
  
  P := GetPrecisionMode();
  if P = pmSingle then pm := 1;
  if P = pmReserved then pm := 2;
  if P = pmDouble then pm := 3;
  if P = pmExtended then pm := 4;

  { WriteLn('pm: ', pm); }
  damath_GetPrecisionMode := pm;
  
end;


exports

damath_setpmExtended,
damath_setpmDouble,
damath_GetPrecisionMode;


begin
end.
