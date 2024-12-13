/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { isRecordNotFoundError } from "../../prisma.util";
import * as errors from "../../errors";
import { Request } from "express";
import { plainToClass } from "class-transformer";
import { ApiNestedQuery } from "../../decorators/api-nested-query.decorator";
import { SkillService } from "../skill.service";
import { SkillCreateInput } from "./SkillCreateInput";
import { Skill } from "./Skill";
import { SkillFindManyArgs } from "./SkillFindManyArgs";
import { SkillWhereUniqueInput } from "./SkillWhereUniqueInput";
import { SkillUpdateInput } from "./SkillUpdateInput";

export class SkillControllerBase {
  constructor(protected readonly service: SkillService) {}
  @common.Post()
  @swagger.ApiCreatedResponse({ type: Skill })
  @swagger.ApiBody({
    type: SkillCreateInput,
  })
  async createSkill(@common.Body() data: SkillCreateInput): Promise<Skill> {
    return await this.service.createSkill({
      data: {
        ...data,

        jobs: data.jobs
          ? {
              connect: data.jobs,
            }
          : undefined,

        staff: data.staff
          ? {
              connect: data.staff,
            }
          : undefined,

        user: data.user
          ? {
              connect: data.user,
            }
          : undefined,
      },
      select: {
        createdAt: true,
        description: true,
        id: true,

        jobs: {
          select: {
            id: true,
          },
        },

        name: true,

        staff: {
          select: {
            id: true,
          },
        },

        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
  }

  @common.Get()
  @swagger.ApiOkResponse({ type: [Skill] })
  @ApiNestedQuery(SkillFindManyArgs)
  async skills(@common.Req() request: Request): Promise<Skill[]> {
    const args = plainToClass(SkillFindManyArgs, request.query);
    return this.service.skills({
      ...args,
      select: {
        createdAt: true,
        description: true,
        id: true,

        jobs: {
          select: {
            id: true,
          },
        },

        name: true,

        staff: {
          select: {
            id: true,
          },
        },

        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
  }

  @common.Get("/:id")
  @swagger.ApiOkResponse({ type: Skill })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async skill(
    @common.Param() params: SkillWhereUniqueInput
  ): Promise<Skill | null> {
    const result = await this.service.skill({
      where: params,
      select: {
        createdAt: true,
        description: true,
        id: true,

        jobs: {
          select: {
            id: true,
          },
        },

        name: true,

        staff: {
          select: {
            id: true,
          },
        },

        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
    if (result === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return result;
  }

  @common.Patch("/:id")
  @swagger.ApiOkResponse({ type: Skill })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  @swagger.ApiBody({
    type: SkillUpdateInput,
  })
  async updateSkill(
    @common.Param() params: SkillWhereUniqueInput,
    @common.Body() data: SkillUpdateInput
  ): Promise<Skill | null> {
    try {
      return await this.service.updateSkill({
        where: params,
        data: {
          ...data,

          jobs: data.jobs
            ? {
                connect: data.jobs,
              }
            : undefined,

          staff: data.staff
            ? {
                connect: data.staff,
              }
            : undefined,

          user: data.user
            ? {
                connect: data.user,
              }
            : undefined,
        },
        select: {
          createdAt: true,
          description: true,
          id: true,

          jobs: {
            select: {
              id: true,
            },
          },

          name: true,

          staff: {
            select: {
              id: true,
            },
          },

          updatedAt: true,

          user: {
            select: {
              id: true,
            },
          },
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }

  @common.Delete("/:id")
  @swagger.ApiOkResponse({ type: Skill })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async deleteSkill(
    @common.Param() params: SkillWhereUniqueInput
  ): Promise<Skill | null> {
    try {
      return await this.service.deleteSkill({
        where: params,
        select: {
          createdAt: true,
          description: true,
          id: true,

          jobs: {
            select: {
              id: true,
            },
          },

          name: true,

          staff: {
            select: {
              id: true,
            },
          },

          updatedAt: true,

          user: {
            select: {
              id: true,
            },
          },
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }
}
