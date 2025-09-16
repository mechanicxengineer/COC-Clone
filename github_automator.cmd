@echo off
:: Git Auto Push Script for Windows CMD

echo ==================================================
echo    🚀 Git Auto Push Tool - Windows CMD Version
echo ==================================================
echo.
echo Current directory: %CD%
echo.

:: Confirm before starting
set /p confirm="Do you want to push this folder to GitHub? (Y/N): "
if /I not "%confirm%"=="Y" (
    echo ❌ Operation cancelled by user.
    pause
    exit /b
)

:: Initialize git if not already a repo
if not exist ".git" (
    echo 📂 Initializing Git repository...
    git init
)

:: Stage all changes
echo 📂 Adding all files...
git add .

:: Commit changes
echo 📝 Committing changes...
git commit -m "Update"

:: Rename branch to main
echo 🌿 Renaming branch to main...
git branch -M main

:: Check if remote is already set
for /f "tokens=*" %%i in ('git remote') do set REMOTE_EXIST=%%i

if not defined REMOTE_EXIST (
    echo 🌐 No remote found.
    set /p remoteurl="Enter your GitHub repository URL (e.g. https://github.com/user/repo.git): "
    git remote add origin %remoteurl%
)

:: Push to GitHub
echo 🚀 Pushing to GitHub...
git push -u origin main

echo ✅ Push completed successfully!
pause