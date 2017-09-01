package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.context.roleplay.quest.GameRolePlayNpcQuestFlag;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayNpcWithQuestInformations extends GameRolePlayNpcInformations implements INetworkType
   {
      
      public static const protocolId:uint = 383;
       
      
      public var questFlag:GameRolePlayNpcQuestFlag;
      
      private var _questFlagtree:FuncTree;
      
      public function GameRolePlayNpcWithQuestInformations()
      {
         this.questFlag = new GameRolePlayNpcQuestFlag();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 383;
      }
      
      public function initGameRolePlayNpcWithQuestInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:uint = 0, param5:Boolean = false, param6:uint = 0, param7:GameRolePlayNpcQuestFlag = null) : GameRolePlayNpcWithQuestInformations
      {
         super.initGameRolePlayNpcInformations(param1,param2,param3,param4,param5,param6);
         this.questFlag = param7;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.questFlag = new GameRolePlayNpcQuestFlag();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayNpcWithQuestInformations(param1);
      }
      
      public function serializeAs_GameRolePlayNpcWithQuestInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayNpcInformations(param1);
         this.questFlag.serializeAs_GameRolePlayNpcQuestFlag(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayNpcWithQuestInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayNpcWithQuestInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.questFlag = new GameRolePlayNpcQuestFlag();
         this.questFlag.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayNpcWithQuestInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayNpcWithQuestInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._questFlagtree = param1.addChild(this._questFlagtreeFunc);
      }
      
      private function _questFlagtreeFunc(param1:ICustomDataInput) : void
      {
         this.questFlag = new GameRolePlayNpcQuestFlag();
         this.questFlag.deserializeAsync(this._questFlagtree);
      }
   }
}
