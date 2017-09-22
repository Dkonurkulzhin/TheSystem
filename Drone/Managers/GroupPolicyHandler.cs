using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone.Managers
{
    static class GroupPolicyHandler
    {

//        static bool SetGroupPolicy(HKEY hKey, LPCTSTR subKey, LPCTSTR valueName, DWORD dwType, const BYTE* szkeyValue, DWORD dwkeyValue)
//        {
//            CoInitialize(NULL);
//        HKEY ghKey, ghSubKey, hSubKey;
//        LPDWORD flag = NULL;
//        IGroupPolicyObject* pGPO = NULL;
//        HRESULT hr = CoCreateInstance(CLSID_GroupPolicyObject, NULL, CLSCTX_ALL, IID_IGroupPolicyObject, (LPVOID*)&pGPO);

//            if(!SUCCEEDED(hr))
//            {
//                MessageBox(NULL, L"Failed to initialize GPO", L"", S_OK);
//    }

//            if (RegCreateKeyEx(hKey, subKey, 0, NULL, REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &hSubKey, flag) != ERROR_SUCCESS)
//            {
//                return false;
//                CoUninitialize();
//}

//            if(dwType == REG_SZ)
//            {
//                if(RegSetValueEx(hSubKey, valueName, 0, dwType, szkeyValue, strlen((char*)szkeyValue) + 1) != ERROR_SUCCESS)
//                {
//                    RegCloseKey(hSubKey);
//                    CoUninitialize();
//                    return false;
//                }
//            }

//            else if(dwType == REG_DWORD)
//            {
//                if(RegSetValueEx(hSubKey, valueName, 0, dwType, (BYTE*)&dwkeyValue, sizeof(dwkeyValue)) != ERROR_SUCCESS)
//                {
//                    RegCloseKey(hSubKey);
//                    CoUninitialize();
//                    return false;
//                }
//            }

//            if(!SUCCEEDED(hr))
//            {
//                MessageBox(NULL, L"Failed to initialize GPO", L"", S_OK);
//                CoUninitialize();
//                return false;
//            }

//            if(pGPO->OpenLocalMachineGPO(GPO_OPEN_LOAD_REGISTRY) != S_OK)
//            {
//                MessageBox(NULL, L"Failed to get the GPO mapping", L"", S_OK);
//                CoUninitialize();
//                return false;
//            }

//            if(pGPO->GetRegistryKey(GPO_SECTION_USER,&ghKey) != S_OK)
//            {
//                MessageBox(NULL, L"Failed to get the root key", L"", S_OK);
//                CoUninitialize();
//                return false;
//            }

//            if(RegCreateKeyEx(ghKey, subKey, 0, NULL, REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &ghSubKey, flag) != ERROR_SUCCESS)
//            {
//                RegCloseKey(ghKey);
//                MessageBox(NULL, L"Cannot create key", L"", S_OK);
//                CoUninitialize();
//                return false;
//            }

//            if(dwType == REG_SZ)
//            {
//                if(RegSetValueEx(ghSubKey, valueName, 0, dwType, szkeyValue, strlen((char*)szkeyValue) + 1) != ERROR_SUCCESS)
//                {
//                    RegCloseKey(ghKey);
//                    RegCloseKey(ghSubKey);
//                    MessageBox(NULL, L"Cannot create sub key", L"", S_OK);
//                    CoUninitialize();
//                    return false;
//                }
//            }

//            else if(dwType == REG_DWORD)
//            {
//                if(RegSetValueEx(ghSubKey, valueName, 0, dwType, (BYTE*)&dwkeyValue, sizeof(dwkeyValue)) != ERROR_SUCCESS)
//                {
//                    RegCloseKey(ghKey);
//                    RegCloseKey(ghSubKey);
//                    MessageBox(NULL, L"Cannot set value", L"", S_OK);
//                    CoUninitialize();
//                    return false;
//                }
//            }

//            if(pGPO->Save(false, true, const_cast<GUID*>(&EXTENSION_GUID), const_cast<GUID*>(&CLSID_GPESnapIn)) != S_OK)
//            {
//                RegCloseKey(ghKey);
//                RegCloseKey(ghSubKey);
//                MessageBox(NULL, L"Save failed", L"", S_OK);
//                CoUninitialize();
//                return false;
//            }

//            pGPO->Release();
//            RegCloseKey(ghKey);
//            RegCloseKey(ghSubKey);
//            CoUninitialize();
//            return true;
//        }

        static void dsdds()
        {

        }
        

    }

}
