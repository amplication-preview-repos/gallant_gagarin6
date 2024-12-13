import { Module } from "@nestjs/common";
import { SkillModuleBase } from "./base/skill.module.base";
import { SkillService } from "./skill.service";
import { SkillController } from "./skill.controller";

@Module({
  imports: [SkillModuleBase],
  controllers: [SkillController],
  providers: [SkillService],
  exports: [SkillService],
})
export class SkillModule {}
