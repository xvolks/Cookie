package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.character.alignment.ActorAlignmentInformations;
   import com.ankamagames.dofus.network.types.game.character.status.PlayerStatus;
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameFightCharacterInformations extends GameFightFighterNamedInformations implements INetworkType
   {
      
      public static const protocolId:uint = 46;
       
      
      public var level:uint = 0;
      
      public var alignmentInfos:ActorAlignmentInformations;
      
      public var breed:int = 0;
      
      public var sex:Boolean = false;
      
      private var _alignmentInfostree:FuncTree;
      
      public function GameFightCharacterInformations()
      {
         this.alignmentInfos = new ActorAlignmentInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 46;
      }
      
      public function initGameFightCharacterInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:uint = 2, param5:uint = 0, param6:Boolean = false, param7:GameFightMinimalStats = null, param8:Vector.<uint> = null, param9:String = "", param10:PlayerStatus = null, param11:uint = 0, param12:ActorAlignmentInformations = null, param13:int = 0, param14:Boolean = false) : GameFightCharacterInformations
      {
         super.initGameFightFighterNamedInformations(param1,param2,param3,param4,param5,param6,param7,param8,param9,param10);
         this.level = param11;
         this.alignmentInfos = param12;
         this.breed = param13;
         this.sex = param14;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.level = 0;
         this.alignmentInfos = new ActorAlignmentInformations();
         this.sex = false;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightCharacterInformations(param1);
      }
      
      public function serializeAs_GameFightCharacterInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightFighterNamedInformations(param1);
         if(this.level < 0 || this.level > 255)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeByte(this.level);
         this.alignmentInfos.serializeAs_ActorAlignmentInformations(param1);
         param1.writeByte(this.breed);
         param1.writeBoolean(this.sex);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightCharacterInformations(param1);
      }
      
      public function deserializeAs_GameFightCharacterInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._levelFunc(param1);
         this.alignmentInfos = new ActorAlignmentInformations();
         this.alignmentInfos.deserialize(param1);
         this._breedFunc(param1);
         this._sexFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightCharacterInformations(param1);
      }
      
      public function deserializeAsyncAs_GameFightCharacterInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._levelFunc);
         this._alignmentInfostree = param1.addChild(this._alignmentInfostreeFunc);
         param1.addChild(this._breedFunc);
         param1.addChild(this._sexFunc);
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readUnsignedByte();
         if(this.level < 0 || this.level > 255)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of GameFightCharacterInformations.level.");
         }
      }
      
      private function _alignmentInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.alignmentInfos = new ActorAlignmentInformations();
         this.alignmentInfos.deserializeAsync(this._alignmentInfostree);
      }
      
      private function _breedFunc(param1:ICustomDataInput) : void
      {
         this.breed = param1.readByte();
      }
      
      private function _sexFunc(param1:ICustomDataInput) : void
      {
         this.sex = param1.readBoolean();
      }
   }
}
