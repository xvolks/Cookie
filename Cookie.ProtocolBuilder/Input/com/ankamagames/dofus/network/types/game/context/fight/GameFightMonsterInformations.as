package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameFightMonsterInformations extends GameFightAIInformations implements INetworkType
   {
      
      public static const protocolId:uint = 29;
       
      
      public var creatureGenericId:uint = 0;
      
      public var creatureGrade:uint = 0;
      
      public function GameFightMonsterInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 29;
      }
      
      public function initGameFightMonsterInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:uint = 2, param5:uint = 0, param6:Boolean = false, param7:GameFightMinimalStats = null, param8:Vector.<uint> = null, param9:uint = 0, param10:uint = 0) : GameFightMonsterInformations
      {
         super.initGameFightAIInformations(param1,param2,param3,param4,param5,param6,param7,param8);
         this.creatureGenericId = param9;
         this.creatureGrade = param10;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.creatureGenericId = 0;
         this.creatureGrade = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightMonsterInformations(param1);
      }
      
      public function serializeAs_GameFightMonsterInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightAIInformations(param1);
         if(this.creatureGenericId < 0)
         {
            throw new Error("Forbidden value (" + this.creatureGenericId + ") on element creatureGenericId.");
         }
         param1.writeVarShort(this.creatureGenericId);
         if(this.creatureGrade < 0)
         {
            throw new Error("Forbidden value (" + this.creatureGrade + ") on element creatureGrade.");
         }
         param1.writeByte(this.creatureGrade);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightMonsterInformations(param1);
      }
      
      public function deserializeAs_GameFightMonsterInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._creatureGenericIdFunc(param1);
         this._creatureGradeFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightMonsterInformations(param1);
      }
      
      public function deserializeAsyncAs_GameFightMonsterInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._creatureGenericIdFunc);
         param1.addChild(this._creatureGradeFunc);
      }
      
      private function _creatureGenericIdFunc(param1:ICustomDataInput) : void
      {
         this.creatureGenericId = param1.readVarUhShort();
         if(this.creatureGenericId < 0)
         {
            throw new Error("Forbidden value (" + this.creatureGenericId + ") on element of GameFightMonsterInformations.creatureGenericId.");
         }
      }
      
      private function _creatureGradeFunc(param1:ICustomDataInput) : void
      {
         this.creatureGrade = param1.readByte();
         if(this.creatureGrade < 0)
         {
            throw new Error("Forbidden value (" + this.creatureGrade + ") on element of GameFightMonsterInformations.creatureGrade.");
         }
      }
   }
}
