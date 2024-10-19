# GL8 Password Manager

**GL8** is a secure password manager built in C# using the Windows Forms framework with MaterialSkin controls. The application focuses on strong encryption, data privacy, and ease of use. It provides users with an intuitive interface to manage their passwords and sensitive information, offering features such as search, CSV import/export, password generation, and encryption using modern cryptographic algorithms like Argon2 and AES-256.

- This is a hobby project in its early development stage. Any feedback that could help with its development will be appreciated.
- Always make a backup of your data (you can use the CSV export function for that).
- Store your master password in a safe place, outside of your device.

## Features

- **Master Password Protection**: GL8 secures all data with a master password, using Argon2 for password hashing and AES-256 for encryption.
- **Password Management**: Add, edit, delete, and search password entries with fields such as website address, login, category, and additional info.
- **Secure Encryption**: All sensitive data is stored encrypted using the Argon2id algorithm for key derivation and AES-256 for encryption, ensuring high security.
- **CSV Import/Export**: Easily import or export password data using CSV files, with customizable column mappings and delimiters.
- **Random Password Generation**: Generate strong, random passwords with custom options for length, character sets, and complexity.
- **User-Friendly Interface**: A MaterialSkin-powered interface with clear dialogs and context menus for copying or editing entries.
- **Data Persistence**: Passwords are securely saved to encrypted files, with support for creating new files if none exist.
- **Public and Private Settings**: Toggle password visibility and other public settings, while saving them securely for future use.

## Screenshots

![image](https://github.com/user-attachments/assets/a7279056-64f9-4f7a-8ef3-c7a751ebccc2)

## Getting Started

### Prerequisites
- .NET Framework 4.7.2 or later
- Visual Studio 2022 or newer

### Installation

1. Clone this repository:
   ```sh
   git clone https://github.com/your-repo/GL8-Password-Manager.git
