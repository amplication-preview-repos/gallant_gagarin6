import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { SkillService } from "./skill.service";
import { SkillControllerBase } from "./base/skill.controller.base";

@swagger.ApiTags("skills")
@common.Controller("skills")
export class SkillController extends SkillControllerBase {
  constructor(protected readonly service: SkillService) {
    super(service);
  }
}
