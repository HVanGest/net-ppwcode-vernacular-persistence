﻿/*
 * Copyright 2004 - $Date: 2008-11-15 23:58:07 +0100 (za, 15 nov 2008) $ by PeopleWare n.v..
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Using

using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

using log4net;

using NHibernate;

using PPWCode.Util.OddsAndEnds.I.Extensions;

using Spring.Context.Support;

using ISession = NHibernate.ISession;

#endregion

namespace PPWCode.Vernacular.Persistence.I.Dao.NHibernate
{
    public class NHibernateContextInitializer
        : IInstanceContextInitializer
    {
        #region Fields

        private static readonly ILog s_Logger = LogManager.GetLogger(typeof(NHibernateContextInitializer));

        #endregion

        public void Initialize(InstanceContext instanceContext, Message message)
        {
            s_Logger.Debug(@"Start NHibernateContextInitializer.Initialize");
            ISessionFactory sessionFactory = ContextRegistry
                .GetContext()
                .GetObject<ISessionFactory>(@"NHibernateSessionFactory");
            ISession session = sessionFactory != null
                                   ? sessionFactory.OpenSession()
                                   : null;
            NHibernateContextExtension nHibernateContextExtension = new NHibernateContextExtension(session);
            s_Logger.Debug(@"Add NHibernateContextExtension" + nHibernateContextExtension);
            instanceContext.Extensions.Add(nHibernateContextExtension);
            s_Logger.Debug(@"End NHibernateContextInitializer.Initialize");
        }
    }
}