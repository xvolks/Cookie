package com.ankamagames.dofus.network.messages.game.context.fight.arena
{
   import com.ankamagames.dofus.network.types.game.character.CharacterBasicMinimalInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ArenaFighterLeaveMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6700;
       
      
      private var _isInitialized:Boolean = false;
      
      public var leaver:CharacterBasicMinimalInformations;
      
      private var _leavertree:FuncTree;
      
      public function ArenaFighterLeaveMessage()
      {
         this.leaver = new CharacterBasicMinimalInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6700;
      }
      
      public function initArenaFighterLeaveMessage(param1:CharacterBasicMinimalInformations = null) : ArenaFighterLeaveMessage
      {
         this.leaver = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.leaver = new CharacterBasicMinimalInformations();
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
         this.serializeAs_ArenaFighterLeaveMessage(param1);
      }
      
      public function serializeAs_ArenaFighterLeaveMessage(param1:ICustomDataOutput) : void
      {
         this.leaver.serializeAs_CharacterBasicMinimalInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ArenaFighterLeaveMessage(param1);
      }
      
      public function deserializeAs_ArenaFighterLeaveMessage(param1:ICustomDataInput) : void
      {
         this.leaver = new CharacterBasicMinimalInformations();
         this.leaver.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ArenaFighterLeaveMessage(param1);
      }
      
      public function deserializeAsyncAs_ArenaFighterLeaveMessage(param1:FuncTree) : void
      {
         this._leavertree = param1.addChild(this._leavertreeFunc);
      }
      
      private function _leavertreeFunc(param1:ICustomDataInput) : void
      {
         this.leaver = new CharacterBasicMinimalInformations();
         this.leaver.deserializeAsync(this._leavertree);
      }
   }
}
