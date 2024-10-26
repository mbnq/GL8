# GL8 Password Manager

**GL8** is a password manager built in C# using the Windows Forms framework with MaterialSkin controls. The application focuses on strong encryption, data privacy, and ease of use. It provides users with an intuitive interface to manage their passwords and sensitive information, offering features such as search, CSV import/export, password generation, and encryption using modern cryptographic algorithms like [Argon2](https://en.wikipedia.org/wiki/Argon2), [AES-256](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard), [Bouncy Castle](https://www.bouncycastle.org/).

- This is a hobby project in its early development stage. Any feedback that could help with its development will be appreciated.
- Always make a backup of your data (you can use the CSV export function for that).
- Create strong, atleast 8 characters long master password. Store your master password in a safe place, outside of your device.

## Updating from Older Versions
<details>
<summary>💾 Click here display 💾</summary>
To update your application from an older version, please follow these steps:

1. **Backup Your Data:**

   - Open the application and navigate to **Settings**.
   - Click on **Backup** to create a backup of your current data.

2. **Export Data as CSV:**

   - While still in **Settings**, select **Export as .csv**.
   - Save the exported `.csv` file to a safe and easily accessible location.

3. **Prepare for the New Version:**

   - Close the application if it's running.
   - Navigate to your application installation directory.
   - **Important:** Delete all files **except** the **Backup** folder. This ensures your backup remains intact.

4. **Install the New Version:**

   - Download and unzip the latest version of the application into your installation directory.

5. **Import Your Data:**

   - Launch the updated application.
   - Go to **Settings** and select **Import**.
   - Choose the `.csv` file you exported earlier.
   - **Note:** When prompted, select **semicolon** as the delimiter during the import process.

6. **Clean Up:**

   - After confirming that your data has been successfully imported, you should delete the `.csv` file.
   - To permanently delete the file on Windows, select it and press **Shift + Delete**.

**Additional Tips:**

- It's recommended to keep a copy of the `.csv` file until you're certain everything is working correctly.
- If you encounter any issues during the update process, consider restoring from the **Backup** folder using your old program version or contact me for assistance.
- Whole process will be improved in future versions.
</details>

## Features

- **Master Password Protection**: GL8 secures all data with a master password, using [Argon2](https://en.wikipedia.org/wiki/Argon2) for password hashing and [AES-256](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard) for encryption.
- **Password Management**: Add, edit, delete, and search password entries with fields such as website address, login, category, and additional info.
- **Secure Encryption**: All sensitive data is stored encrypted using the Argon2id algorithm for key derivation and AES-256 for encryption, ensuring high security.
- **CSV Import/Export**: Easily import or export password data using [CSV files](https://en.wikipedia.org/wiki/Comma-separated_values), with customizable column mappings and delimiters.
- **Random Password Generation**: Generate strong, random passwords with custom options for length, character sets, and complexity.
- **User-Friendly Interface**: A [MaterialSkin-powered](https://www.nuget.org/packages/MaterialSkin.2) interface with clear dialogs and context menus for copying or editing entries.
- **Data Persistence**: Passwords are securely saved to encrypted files, with support for creating new files if none exist.
- **Public and Private Settings**: Toggle password visibility and other public settings, while saving them securely for future use.

## Screenshots

![image](https://github.com/user-attachments/assets/5cda2902-f6c0-46cd-ab1a-cc8922a7a9e0)

## Getting Started

### Prerequisites
- .NET Framework 4.7.2 or later
- Visual Studio 2022 or newer
