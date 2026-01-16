@echo off

echo [INFO] 檢查並刪除 Listings 資料夾...

if exist .\Listings (
  rd /s /q .\Listings
  echo [INFO] Listings 資料夾已刪除。
) else (
  echo [INFO] Listings 資料夾不存在，略過。
)
