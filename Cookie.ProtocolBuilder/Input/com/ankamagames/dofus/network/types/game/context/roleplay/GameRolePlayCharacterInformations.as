package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.character.alignment.ActorAlignmentInformations;
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayCharacterInformations extends GameRolePlayHumanoidInformations implements INetworkType
   {
      
      public static const protocolId:uint = 36;
       
      
      public var alignmentInfos:ActorAlignmentInformations;
      
      private var _alignmentInfostree:FuncTree;
      
      public function GameRolePlayCharacterInformations()
      {
         this.alignmentInfos = new ActorAlignmentInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 36;
      }
      
      public function initGameRolePlayCharacterInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:String = "", param5:HumanInformations = null, param6:uint = 0, param7:ActorAlignmentInformations = null) : GameRolePlayCharacterInformations
      {
         super.initGameRolePlayHumanoidInformations(param1,param2,param3,param4,param5,param6);
         this.alignmentInfos = param7;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.alignmentInfos = new ActorAlignmentInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayCharacterInformations(param1);
      }
      
      public function serializeAs_GameRolePlayCharacterInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayHumanoidInformations(param1);
         this.alignmentInfos.serializeAs_ActorAlignmentInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayCharacterInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayCharacterInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.alignmentInfos = new ActorAlignmentInformations();
         this.alignmentInfos.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayCharacterInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayCharacterInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._alignmentInfostree = param1.addChild(this._alignmentInfostreeFunc);
      }
      
      private function _alignmentInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.alignmentInfos = new ActorAlignmentInformations();
         this.alignmentInfos.deserializeAsync(this._alignmentInfostree);
      }
   }
}
