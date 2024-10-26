# GL8 Password Manager

**GL8** is a password manager built in C# using the Windows Forms framework with MaterialSkin controls. The application focuses on strong encryption, data privacy, and ease of use. It provides users with an intuitive interface to manage their passwords and sensitive information, offering features such as search, CSV import/export, password generation, and encryption using modern cryptographic algorithms like [Argon2](https://en.wikipedia.org/wiki/Argon2) and [AES-256](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard).

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

### Installation

1. get latest .zip from here [https://github.com/mbnq/GL8/releases](https://github.com/mbnq/GL8/releases)

or

1. Clone this repository:
   ```sh
   git clone https://github.com/your-repo/GL8-Password-Manager.git

## **Security Overview of GL8 Password Manager**

GL8 Password Manager is designed with strong security measures to ensure the protection of user data. Below is an overview (written by AI) of the key security features implemented in the program:

#### **1. Strong Encryption (AES-256)**
   - The program uses **AES-256**, a widely recognized and highly secure encryption standard, to protect all password data. AES-256 provides 256-bit encryption, making brute-force attacks infeasible with current technology.
   - All sensitive data, including the password list, is encrypted before being saved to disk, ensuring that even if the data file is accessed by an unauthorized user, it remains unreadable without the master password.

#### **2. Secure Key Derivation (Argon2id)**
   - **Argon2id** is used for deriving cryptographic keys from the user’s master password. Argon2id is the winner of the Password Hashing Competition (PHC) and is designed to resist GPU-based and other types of brute-force attacks.
   - The program configures Argon2id with:
     - **Degree of Parallelism**: 8 (uses multiple CPU cores for increased security).
     - **Memory Size**: 48 MB (memory-hardness increases the cost of brute-force attacks).
     - **Iterations**: 8 (multiple iterations make password hashing slower for attackers).
   - Argon2id ensures that the encryption key is securely derived from the user's password, enhancing protection against attacks.

#### **3. Salted Hashing**
   - A **unique salt** is generated and used with each password to ensure that even if two users select the same password, the resulting hashes are different. This prevents **rainbow table** attacks, where precomputed hashes are used to quickly break passwords.
   - The salted hash of the master password is stored securely, and only the correct master password can be used to decrypt the stored data.

#### **4. Secure Password Handling**
   - GL8 uses **SecureString** for handling passwords in memory. This ensures that sensitive information, like the master password, is stored securely and minimizes exposure to memory attacks.
   - Passwords are automatically cleared from memory when no longer needed to further reduce the risk of data leaks.

#### **5. Encryption Keys Derived from the Master Password**
   - The encryption and decryption operations use keys derived from the master password via Argon2id. This ensures that only the user who knows the master password can decrypt the stored password data.
   - Without the correct master password, the encrypted data is completely unreadable.

#### **6. Decryption Requires the Master Password**
   - Even if an attacker gains access to the encrypted file (e.g., through unauthorized access to the disk), they will still need the master password to decrypt and read the data. This adds a critical layer of protection, ensuring that stolen files remain secure.

### **Additional Considerations**

While GL8 Password Manager incorporates strong security mechanisms, users should be aware of the following best practices:

1. **Password Strength**:
   - The security of the stored data depends on the strength of the master password. Users are encouraged to create strong passwords (e.g., at least 12 characters, including upper/lowercase letters, numbers, and symbols).
   - Implementing a password strength meter can guide users toward selecting stronger passwords.

2. **Master Password Management**:
   - Users are advised to periodically change their master password. The application provides options to re-encrypt data when the master password is updated, ensuring continued security.

### **Conclusion**
GL8 Password Manager follows best practices for encryption and password protection, making it highly secure for storing sensitive password data. By using AES-256 encryption, Argon2id for key derivation, and secure password handling techniques, the program ensures that user data is protected both in memory and on disk.

