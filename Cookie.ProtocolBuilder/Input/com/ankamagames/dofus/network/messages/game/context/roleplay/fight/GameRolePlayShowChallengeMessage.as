package com.ankamagames.dofus.network.messages.game.context.roleplay.fight
{
   import com.ankamagames.dofus.network.types.game.context.fight.FightCommonInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayShowChallengeMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 301;
       
      
      private var _isInitialized:Boolean = false;
      
      public var commonsInfos:FightCommonInformations;
      
      private var _commonsInfostree:FuncTree;
      
      public function GameRolePlayShowChallengeMessage()
      {
         this.commonsInfos = new FightCommonInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 301;
      }
      
      public function initGameRolePlayShowChallengeMessage(param1:FightCommonInformations = null) : GameRolePlayShowChallengeMessage
      {
         this.commonsInfos = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.commonsInfos = new FightCommonInformations();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayShowChallengeMessage(param1);
      }
      
      public function serializeAs_GameRolePlayShowChallengeMessage(param1:ICustomDataOutput) : void
      {
         this.commonsInfos.serializeAs_FightCommonInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayShowChallengeMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayShowChallengeMessage(param1:ICustomDataInput) : void
      {
         this.commonsInfos = new FightCommonInformations();
         this.commonsInfos.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayShowChallengeMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayShowChallengeMessage(param1:FuncTree) : void
      {
         this._commonsInfostree = param1.addChild(this._commonsInfostreeFunc);
      }
      
      private function _commonsInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.commonsInfos = new FightCommonInformations();
         this.commonsInfos.deserializeAsync(this._commonsInfostree);
      }
   }
}
