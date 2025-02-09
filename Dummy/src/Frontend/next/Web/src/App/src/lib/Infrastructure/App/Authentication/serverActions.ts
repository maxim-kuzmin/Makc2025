'use server';

import { AuthError } from 'next-auth';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';
import { createAppApiErrorResourcesOptions } from '@/lib';
import indexContext from '@/lib/indexContext';

export async function serverActionToAppAuthenticationLogin(
  prevState: string | undefined,
  formData: FormData,
) {
  const password = formData.get('password');
  const userName = formData.get('userName');

  const language = serverContext.app.localization.getCurrentLanguage();

  const appApiErrorResources = await serverContext.app.api.getErrorResources();

  const appApiErrorResourcesOptions = JSON.stringify(createAppApiErrorResourcesOptions({
    ...appApiErrorResources
  }));

  const t = await serverContext.app.localization.getTranslator();

  const { signIn } = modules.app.authentication.getNextAuth();

  try {
    await signIn('credentials', {
      redirectTo: indexContext.app.getHrefToRoot(),
      appApiErrorResourcesOptions,
      language,
      password,
      userName
    });
  } catch (error) {
    if (error instanceof AuthError) {
      switch (error.type) {
        case 'CredentialsSignin':
          return t('lib.app.authentication.serverActions.login.ErrorMessageForCredentialsSignin');
        default:
          return t('lib.app.authentication.serverActions.login.ErrorMessage');
      }
    }
    throw error;
  }
}

export async function serverActionToAppAuthenticationLogout() {
  const { signOut } = modules.app.authentication.getNextAuth();

  await signOut({ redirectTo: indexContext.app.getHrefToRoot() });
}
