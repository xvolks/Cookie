package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.dofus.network.messages.game.actions.AbstractGameActionMessage;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameActionFightTriggerGlyphTrapMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5741;
       
      
      private var _isInitialized:Boolean = false;
      
      public var markId:int = 0;
      
      public var triggeringCharacterId:Number = 0;
      
      public var triggeredSpellId:uint = 0;
      
      public function GameActionFightTriggerGlyphTrapMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5741;
      }
      
      public function initGameActionFightTriggerGlyphTrapMessage(param1:uint = 0, param2:Number = 0, param3:int = 0, param4:Number = 0, param5:uint = 0) : GameActionFightTriggerGlyphTrapMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.markId = param3;
         this.triggeringCharacterId = param4;
         this.triggeredSpellId = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.markId = 0;
         this.triggeringCharacterId = 0;
         this.triggeredSpellId = 0;
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameActionFightTriggerGlyphTrapMessage(param1);
      }
      
      public function serializeAs_GameActionFightTriggerGlyphTrapMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         param1.writeShort(this.markId);
         if(this.triggeringCharacterId < -9007199254740990 || this.triggeringCharacterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.triggeringCharacterId + ") on element triggeringCharacterId.");
         }
         param1.writeDouble(this.triggeringCharacterId);
         if(this.triggeredSpellId < 0)
         {
            throw new Error("Forbidden value (" + this.triggeredSpellId + ") on element triggeredSpellId.");
         }
         param1.writeVarShort(this.triggeredSpellId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightTriggerGlyphTrapMessage(param1);
      }
      
      public function deserializeAs_GameActionFightTriggerGlyphTrapMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._markIdFunc(param1);
         this._triggeringCharacterIdFunc(param1);
         this._triggeredSpellIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightTriggerGlyphTrapMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightTriggerGlyphTrapMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._markIdFunc);
         param1.addChild(this._triggeringCharacterIdFunc);
         param1.addChild(this._triggeredSpellIdFunc);
      }
      
      private function _markIdFunc(param1:ICustomDataInput) : void
      {
         this.markId = param1.readShort();
      }
      
      private function _triggeringCharacterIdFunc(param1:ICustomDataInput) : void
      {
         this.triggeringCharacterId = param1.readDouble();
         if(this.triggeringCharacterId < -9007199254740990 || this.triggeringCharacterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.triggeringCharacterId + ") on element of GameActionFightTriggerGlyphTrapMessage.triggeringCharacterId.");
         }
      }
      
      private function _triggeredSpellIdFunc(param1:ICustomDataInput) : void
      {
         this.triggeredSpellId = param1.readVarUhShort();
         if(this.triggeredSpellId < 0)
         {
            throw new Error("Forbidden value (" + this.triggeredSpellId + ") on element of GameActionFightTriggerGlyphTrapMessage.triggeredSpellId.");
         }
      }
   }
}
