﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace FeriaVirtual.API.App_Start {

    public class AccessPolicyCors:Attribute, ICorsPolicyProvider {

        public async Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request,CancellationToken cancellationToken) {
            CorsRequestContext corsRequestContext = request.GetCorsRequestContext();
            string originRequested = corsRequestContext.Origin;
            if(await IsOriginFromCustomer(originRequested)) {
                CorsPolicy policy = new CorsPolicy {
                    AllowAnyHeader = true,
                    AllowAnyMethod = true
                };
                policy.Origins.Add(originRequested);
                return policy;
            }
            return null;
        }

        private async Task<bool> IsOriginFromCustomer(string originRequested) {
            return true;
        }

    }

}