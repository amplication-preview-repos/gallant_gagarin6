import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { StaffAgencyService } from "./staffAgency.service";
import { StaffAgencyControllerBase } from "./base/staffAgency.controller.base";

@swagger.ApiTags("staffAgencies")
@common.Controller("staffAgencies")
export class StaffAgencyController extends StaffAgencyControllerBase {
  constructor(protected readonly service: StaffAgencyService) {
    super(service);
  }
}
